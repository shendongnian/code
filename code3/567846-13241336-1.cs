    private async Task<string> RequestData(string uri)
    {
      using (var client = new HttpClient())
      {
        return await client.GetStringAsync(uri);
      }
    }
