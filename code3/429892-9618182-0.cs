        public static string GetAppConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? GetAppConfigValue(GetAppConfigFileName(), key);
        }
        private static string GetAppConfigValue(string appConfigFileName, string key)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = appConfigFileName;
            Configuration appConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return appConfig.AppSettings.Settings[key].Value;
        }
