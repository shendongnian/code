    public static object GetSection(string sectionName)
    {
    	if (string.IsNullOrEmpty(sectionName))
    	{
    		return null;
    	}
    	ConfigurationManager.PrepareConfigSystem();
    	return ConfigurationManager.s_configSystem.GetSection(sectionName);
    }
