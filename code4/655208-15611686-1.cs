    int x = 0;
    Task<int> task = Task.Factory.StartNew (() => 7 / x);
    try
    {
        task.Wait();
        // OR.
        int result = task.Result;
    }
    catch (AggregateException aggEx)
    {
        Console.WriteLine(aggEx.InnerException.Message);
    }
