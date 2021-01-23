    public async Task MyOuterMethod()
    {
        // let's say there is a list of 1000+ URLs
        var urls = { "http://google.com", "http://yahoo.com", ... };
        // now let's send HTTP requests to each of these URLs in parallel
        var allTasks = new List<Task>();
        var throttler = new SemaphoreSlim(initialCount: 20);
        foreach (var url in urls)
        {
            // do an async wait until we can schedule again
            await throttler.WaitAsync();
            // using Task.Run(...) to run the lambda in its own parallel
            // flow on the threadpool
            allTasks.Add(
                Task.Run(async () =>
                {
                    try
                    {
                        var client = new HttpClient();
                        var html = await client.GetStringAsync(url);
                    }
                    finally
                    {
                        throttler.Release();
                    }
                }));
        }
        // won't get here until all urls have been put into tasks
        await Task.WhenAll(allTasks);
        // won't get here until all tasks have completed in some way
        // (either success or exception)
    }
