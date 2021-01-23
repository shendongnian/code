    public static bool IsFourthLaunch = false;
    
    ApplicationLaunching(){
    
    if (!IsolatedStorageSettings.ApplicationSettings.Contains("IsFourthLaunchDone"))
    {
         IsFourthLaunch = true;
    }
    
    }
