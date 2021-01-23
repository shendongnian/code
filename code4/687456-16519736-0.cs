    public static void UpdateKey(string key, string newValue) 
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(GetAppPath() + "MyAppName.exe");
        config.AppSettings.Settings[key].Value = newValue;
        config.Save();
    } 
