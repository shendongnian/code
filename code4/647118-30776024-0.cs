    class ConfigurationProvider
    {
        private static string GetStorageConnectionString(string name)
        {
            try
            {
                return RoleEnvironment.GetConfigurationSettingValue(name);
            }
            catch (SEHException)
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
        }
        public static string StorageConnectionString()
        {
            return GetStorageConnectionString("StorageConnectionString");
        }
     
        public static string DefaultConnection()
        {
            return GetStorageConnectionString("DefaultConnection");
        }
    }
