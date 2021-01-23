    var parent = Task.Factory.StartNew(
      () =>
      {
        var semaphore = new SemaphoreSlim(5, 5);
        foreach (var workitem in YourWorkItems)
        {
          var capture = workitem;
          semaphore.WaitOne();
          Task.Factory.StartNew(
            () =>
            {
              try
              {
                CallWebService(capture);
              }
              finally
              {
                semaphore.Release();
              }
            }, TaskCreationOptions.AttachedToParent);
        }
      }, TaskCreationOptions.LongRunning);
    // Optionally wait for the parent to complete here.
    // Because our child tasks are attached this will wait until everything is done.
    parent.Wait(); 
 
