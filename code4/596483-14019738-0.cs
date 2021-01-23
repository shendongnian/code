    StopWatch sw = Stopwatch.StartNew();
    
    for(int index = 0; index < 10; index++)
    {
        DoSomething();
        Console.WriteLine(sw.MilliSeconds)
    }
    
    sw.Stop();
