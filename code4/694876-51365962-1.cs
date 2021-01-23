    System.Configuration.Configuration configFile = null;
    if (System.Web.HttpContext.Current != null)
    {
        configFile =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
    }
    else
    {
        System.Configuration.ExeConfigurationFileMap map = new ExeConfigurationFileMap { ExeConfigFilename = $"{System.AppDomain.CurrentDomain.BaseDirectory}Web.Config" };
        configFile = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
    }
