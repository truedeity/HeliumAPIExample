using System;
using System.Net.Http;
using System.Text.Json;

namespace HeliumAPIExample
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.helium.io/v1/");

            var response = await client.GetAsync("blockchain");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var blockchainInfo = JsonSerializer.Deserialize<BlockchainInfo>(content);

            Console.WriteLine($"Blockchain height: {blockchainInfo.height}");
        }
    }

    class BlockchainInfo
    {
        public int height { get; set; }
    }
}
