    static async Task DoWork()
    {
      // By default, ActionBlock uses MaxDegreeOfParallelism == 1,
      //  so AThreadUnsafeMethod is not called in parallel.
      var block = new ActionBlock<Item>(AThreadUnsafeMethod);
      // Start off N tasks, each asynchronously acquiring 10 items.
      // Each item is sent to the block as it is received.
      var tasks = Enumerable.Range(0, N).Select(Task.Run(
          async () =>
          {
            for (int i = 0; i != 10; ++i)
              block.Post(await GetItemAsync());
          })).ToArray();
      // Complete the block when all tasks have completed.
      Task.WhenAll(tasks).ContinueWith(_ => { block.Complete(); });
      // Wait for the block to complete.
      await block.Completion;
    }
