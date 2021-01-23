    try
    {
        Task.WaitAll(tasks);
    }
    catch(AggregateException ex)
    {
        foreach(Exception in ex.InnerExceptions) { ... }
    }
