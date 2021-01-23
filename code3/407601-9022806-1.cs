    //This reference is necessary if you want to discover information regarding
    // the current instance of a deployed application.
    using System.Deployment.Application;
    
    //Method to obtain your applications data directory
    public static string GetAppDataDirectory()
    {
        //The static, IsNetworkDeployed property let's you know if
        // an application has been deployed via ClickOnce.
        if (ApplicationDeployment.IsNetworkDeployed)
    
            //In case of a ClickOnce install, return the deployed apps data directory
            //  (This is located within the User's folder, but differs between
            //  versions of Windows.)
            return ApplicationDeployment.CurrentDeployment.DataDirectory;
        //Otherwise, return another location.  (Application.StartupPath works well with debugging.)
        else return Application.StartupPath;
     }
