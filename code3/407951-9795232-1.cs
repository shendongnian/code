    if (ApplicationDeployment.IsNetworkDeployed && 
        ApplicationDeployment.CurrentDeployment.IsFirstRun)
    {
         Settings.Default.IsFirstRun = false;
         Settings.Default.Save();
    }
    
    ....
    if (Settings.Default.IsFirstRun)
    {
        // simply test here to see if its first run
        // you can just flip flag flag in the settings 
        // to acheive the same result.
    }
    
