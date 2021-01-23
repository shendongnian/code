    static void SaveVersion(string configFile, string version) 
    {
        var myConfig = ConfigurationManager.OpenExeConfiguration(configFile);
        myConfig.AppSettings.Settings["AgentVersion"].Value = version;
        myConfig.Save();
    }
