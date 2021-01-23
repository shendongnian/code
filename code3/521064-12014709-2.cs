    public static Configuration LoadConfig()
    {
        Assembly currentAssembly = Assembly.GetCallingAssembly();
        string configPath = new Uri(currentAssembly.CodeBase).LocalPath;
        return ConfigurationManager.OpenExeConfiguration(configPath);
    }
