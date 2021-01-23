    public static void IncrementCountMetricBy(string name, int count)
    {
        var tmp = _metrics;
        Thread.Sleep(1000);           
        tmp.AddOrUpdate(...);
    }
