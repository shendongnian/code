    private ServerConnection LoadConnectionDetailsFromDisk(string flowProcess)
    {
       var appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
       var bodyFile = Path.Combine(appPath, @"XML\ServerConnections.xml");
        if (FileExists(bodyFile))
        {
            //more logic
        }
    }
    public bool FileExists(bodyFile) { return File.Exists(bodyFile) }
