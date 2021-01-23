    public static Configuration LoadConfig()
    {
        Assembly currentAssembly = Assembly.GetCallingAssembly();
        return ConfigurationManager.OpenExeConfiguration(currentAssembly.Location);
    }
