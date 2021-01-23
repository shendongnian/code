    var stopwatch = Stopwatch.StartNew();
    for (int i = 1; i < 100000000; i++)
    {
        Fibo(100);
    }
    stopwatch.Stop();
    Console.WriteLine("Elapsed time: {0}", stopwatch.Elapsed);
