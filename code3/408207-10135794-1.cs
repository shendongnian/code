    protected void Application_Start()
    {
           MiniProfilerEF.Initialize();
           // Start access database from here ...
           // For example call MyDbContext.Database.Exists();
    }
