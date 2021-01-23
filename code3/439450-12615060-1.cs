    public static ConnectionStringSettings ConnSettings
    {
        get
        {
            string connectionStringKey = null;
            connectionStringKey = ConfigurationManager.AppSettings.Get("DefaultConnectionString");
            return ConfigurationManager.ConnectionStrings[connectionStringKey];          
        }
    }
