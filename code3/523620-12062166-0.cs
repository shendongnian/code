            System.Configuration.KeyValueConfigurationCollection settings;
            System.Configuration.Configuration config;
            System.Configuration.ExeConfigurationFileMap configFile = new System.Configuration.ExeConfigurationFileMap();
            configFile.ExeConfigFilename = "my_file.config";
            config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFile, System.Configuration.ConfigurationUserLevel.None);
            settings = config.AppSettings.Settings;
