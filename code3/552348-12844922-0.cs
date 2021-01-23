    public static void PerformanceTest<T>(Func<T> func, int iterations)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < iterations; i++)
        {
          var x = func();
        }
        stopWatch.Stop();
    
        Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
