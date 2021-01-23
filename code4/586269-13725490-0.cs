            System.Configuration.KeyValueConfigurationCollection settings;
            System.Configuration.Configuration config;
            System.Configuration.ExeConfigurationFileMap configFile = new System.Configuration.ExeConfigurationFileMap();
            configFile.ExeConfigFilename = "App.config";
            config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFile, System.Configuration.ConfigurationUserLevel.None);
            settings = config.AppSettings.Settings;
            config.AppSettings.Settings.Add(new System.Configuration.KeyValueConfigurationElement("myKey", "myValue"));
            config.Save();
