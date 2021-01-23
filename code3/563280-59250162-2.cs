    public static class ExtensionMethods
    {
      public static async Task<string> DownloadStringAsync(this HttpClient client, string url)
      {
        var response = await client.SendAsync(new HttpRequestMessage(
          HttpMethod.Get, url));
    
        return await response.Content.ReadAsStringAsync();
      }
    }
