    var bag = new ConcurrentBag<object>();
    var maxParallel = 20;
    var throttler = new SemaphoreSlim(initialCount: maxParallel);
    var tasks = myCollection.Select(async item =>
    {
      try
      {
         await throttler.WaitAsync();
         var response = await GetData(item);
         bag.Add(response);
      }
      finally
      {
         throttler.Release();
      }
    });
    await Task.WhenAll(tasks);
    var count = bag.Count;
