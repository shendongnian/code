    var g = Task.Factory.StartNew(() => 8)
           .ContinueWith(ant => { throw null; })
           // Using our extension method instead of simple ContinueWith
           .TransformWith(t => Console.WriteLine("OK"));
    
    try
    {
        Console.WriteLine("1");
        // Will fail with NullReferenceException (inside AggregateExcpetion)
        g.Wait();
        Console.WriteLine("2");
    }
    
    catch (AggregateException ex)
    {
        // ex.InnerException is a NullReferenceException
        Console.WriteLine(ex.InnerException);
    }
