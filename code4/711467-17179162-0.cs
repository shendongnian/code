    static void SaveVersion(string configFile, string version) 
    {
        var myConfig = WebConfigurationManager.OpenWebConfiguration(configFile);
        myConfig.AppSettings.Settings.Item("AgentVersion").Value = version;
        myConfig.Save();
    }
