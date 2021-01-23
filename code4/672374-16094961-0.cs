    static void Main(string[] args)
    {
      DownloadAsync("http://an.invalid.url.com);
      Console.ReadKey();
    }
    async static Task DownloadAsync(string url)
    {
      using (var client = new System.Net.Http.HttpClient())
      {
        string text = await client.GetStringAsync(url);
        Console.WriteLine("Downloaded {0} chars", text.Length);
      }
    }
