    List<Task<ReturnObject>> workTasks =
      collection.Select( o => o.DoWork() ).ToList();
    List<Task> resultTasks =
      workTasks.Select( o => o.ContinueWith( t =>
          {
            ReturnObject r = t.Result;
            // do something with the result
          },
          // if you want to run this on the UI thread
          TaskScheduler.FromCurrentSynchronizationContext()
        )
      )
      .ToList();
    await Task.WhenAll( resultTasks );
      
