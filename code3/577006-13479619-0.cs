    private static long Measure(int iterations, Action action)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < iterations; i++)
        {
            action();
        }
            
        stopwatch.Stop();
        return stopwatch.ElapsedTicks;
    }
