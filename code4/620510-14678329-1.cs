    public async Task getThreadContentsAsync(String[] threads)
    {
      HttpClient client = new HttpClient();
      ConcurrentDictionary<String, object> usernames = new ConcurrentDictionary<String, object>();
      await threads.ForEachAsync(8, async url =>
      {
        HttpResponseMessage response = await client.GetAsync(url);
        String content = await response.Content.ReadAsStringAsync();
        String user;
        foreach (Match match in regex.Matches(content))
        {
          user = match.Groups[1].ToString();
          usernames.TryAdd(user, null);
        }
        progressBar1.PerformStep();
      });
    }
