    using System.Deployment.Application;
    public Version AssemblyVersion 
    {
        get
        {
            return ApplicationDeployment.CurrentDeployment.CurrentVersion;
        }
    }
