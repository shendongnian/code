    Task t1 = Task.Factory.StartNew(() => { throw new Exception(); });
    Task t2 = Task.Factory.StartNew(() => { throw new Exception(); });
    Task t3 = Task.WhenAll(t1, t2)
        .ContinueWith(t => t.Exception.InnerExceptions.Count(), 
        TaskContinuationOptions.OnlyOnFaulted);
