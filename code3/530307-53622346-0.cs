    using System.Net.Http;
    
    namespace ConsoleApp2
    {
        class Program
        {
            async static void Main(string[] args)
            {
                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync("https://example.com/test.txt");
            }
        }
    }
