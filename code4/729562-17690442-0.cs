    using System.Deployment;
    using System.Reflection;
    Version theVersion;
    try
    {
        theVersion = Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
    }
    catch
    {
        theVersion = Assembly.GetExecutingAssembly().GetName().Version;
    }
