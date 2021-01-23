    try
    {
        task.Wait();
    }
    catch (AggregateException aex)
    {
        Console.Write(aex.InnerException.Message);
    }
