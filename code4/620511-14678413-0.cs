    public async Task getThreadContentsAsync(String[] threads)
    {
      SemaphoreSlim semaphore = new SemaphoreSlim(8);
      HttpClient client = new HttpClient();
      ConcurrentDictionary<String, object> usernames = new ConcurrentDictionary<String, object>();
      await Task.WhenAll(threads.Select(async url =>
      {
        await semaphore.WaitAsync();
        try
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
        }
        finally
        {
          semaphore.Release();
        }
      }));
    }
