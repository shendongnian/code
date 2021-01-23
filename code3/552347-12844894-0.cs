    public static void PerformanceTest<T>(Func<T> func, int iterations)
    {
        var stopWatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            T x = func();
        }
        stopWatch.Stop();
    
        Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
