        public static string GetConfigurationValue(string pstrKey)
        {
            var configurationValue = ConfigurationManager.AppSettings[pstrKey];
            if (!string.IsNullOrWhiteSpace(configurationValue))
                return configurationValue;
            throw (new ApplicationException(
                "Configuration Tag is missing web.config. It should contain   <add key=\"" + pstrKey + "\" value=\"?\"/>"));
        }
