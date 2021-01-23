    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        if (WebConfigSettings.ShowMemoryUsage)
        {
            GC.Collect();
            logger.Debug(string.Format("Total memory: {0:###,###,###,##0} bytes", GC.GetTotalMemory(true)));
        }
    }
