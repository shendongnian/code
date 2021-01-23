    try
    {
        SomethingBad();
    }
    catch(AggregateException ae)
    {
        foreach(var e in ae.InnerExceptions)
           Console.WriteLine(e.Message);
    }
