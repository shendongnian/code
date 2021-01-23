    class MainClass
    {
        public static void Main()
        {
            new Client().HttpClientCallAsync().Wait();
        }
    }
    public class Client
    {
        HttpClient client = new HttpClient();
        public async Task HttpClientCallAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://vendhq.com");
            string responseAsString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseAsString);
        }
    }
