    string SetupIIS()
    {
        var featureNames = new [] 
        {
            "IIS-ApplicationDevelopment",
            "IIS-CommonHttpFeatures",
            "IIS-DefaultDocument",
            "IIS-ISAPIExtensions",
            "IIS-ISAPIFilter",
            "IIS-ManagementConsole",
            "IIS-NetFxExtensibility",
            "IIS-RequestFiltering",
            "IIS-Security",
            "IIS-StaticContent",
            "IIS-WebServer",
            "IIS-WebServerRole",
        };
        return ProcessEx.Run(
            "dism",
            string.Format(
                "/NoRestart /Online /Enable-Feature {0}",
                string.Join(
                    " ", 
                    featureNames.Select(name => string.Format("/FeatureName:{0}",name)))));
    }           
----------
    static string Run(string fileName, string arguments)
    {
        using (var process = Process.Start(new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = true,
            UseShellExecute = false,
        }))
        {
            process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }
    } 
