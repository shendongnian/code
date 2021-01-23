    bool tablesInitialized = false;
    if (runInDemoMode)
    {
        lock (this)
        {
            if (!tablesInitialized)
            {
                //Initalization of tables
                dCreator.createInitialTables();
                SetupPlugins();
                AutoConfigure(database);
            
                tablesInitialized = true;
            }
            //Simulator                   
            sim.processSimulatedData();
        }
        return;
    }
