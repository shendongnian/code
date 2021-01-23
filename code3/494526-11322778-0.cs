    using StackExchange.Profiling;
    ...    
    protected void Application_BeginRequest()
    {
        if (Request.IsLocal)
        {
            MiniProfiler.Start();
        } 
    }
