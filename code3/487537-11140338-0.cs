    private ServerConnection LoadConnectionDetailsFromDisk(string flowProcess)
    {
       var appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
       var bodyFile = Path.Combine(appPath, @"XML\ServerConnections.xml");
        if (File.Exists(bodyFile))
        {
            //more logic
        }
    }
