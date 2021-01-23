    Stopwatch sw;
    
    for(int index = 0; index < 10; index++)
    {
        sw = Stopwatch.StartNew();
        DoSomething();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
    
    sw.Stop();
