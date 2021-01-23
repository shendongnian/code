    public static class SharedConfiguration
    {
    	public static readonly Configuration instance = GetConfiguration("Shared.config");
    	private static Configuration GetConfiguration(string configFileName)
    	{
    		ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap();
    		Uri uri = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
    		exeConfigurationFileMap.ExeConfigFilename = Path.Combine(uri.LocalPath, configFileName);
    		return ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
    	}
    }
