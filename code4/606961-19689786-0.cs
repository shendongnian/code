    protected void Application_EndRequest()
    {
        // not production code!
        MiniProfiler.Stop();
        var logger = NLog.LogManager.GetCurrentClassLogger();
        var instance = MiniProfiler.Current;
        if (instance == null) return;
        var t = instance.GetSqlTimings();
        foreach (var sqlTiming in t)
        {
            logger.Debug(sqlTiming.CommandString);
        }
    }
