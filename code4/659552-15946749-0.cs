    async Task<IEnumerable<string>> GetAddresses(IEnumerable<string> hosts, int timeoutms)
    {
      List<Task<string>> tasks = new List<Task<string>>();
      tasks.Add(null);
      foreach (var host in hosts)
      {
        tasks.Add(GetEntryAsync(host);
      }
      var wait = Task.Delay(timeoutms); // create a task that will fire when time passes.
      var any = await Task.WhenAny(
                        wait, 
                        Task.WhenAll(tasks)); // Wait for EITHER timeout or ALL the dns reqs.
      if (any == wait)
      {
        throw new MyTimeoutException();
      }
    
      return tasks.Select(t => t.Result).ToArray(); // Should also check for exceptions here.
    }
