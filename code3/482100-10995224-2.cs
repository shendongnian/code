    private static TimeSpan ExecuteOneWayTest(int iterations)
    {
        var stopwatch = Stopwatch.StartNew();
        for (var i = 1; i < iterations; i++)
        {
            TestingOperationOneWay();
        }
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
