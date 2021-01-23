    private static readonly object _locker = new object();
    public SomeClass(bool runInDemoMode)
    {
        if (runInDemoMode)
        {
            lock (_locker)
            {
                if (runInDemoMode)
                {
                    //Initalization of tables
                    dCreator.createInitialTables();
                    SetupPlugins();
                    AutoConfigure(database);
    
                    //Simulator                   
                    sim.processSimulatedData();
                }
            }
        }
    }
