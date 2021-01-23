    public static string ReadSetting(string key)
        {
            System.Configuration.Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.AppSettingsSection appSettings = (System.Configuration.AppSettingsSection)cfg.GetSection("appSettings");
            return appSettings.Settings[key].Value;
           
        }
