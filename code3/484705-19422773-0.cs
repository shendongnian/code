    //Read WebAppConfiguration
    public static AppSettingsSection ReadAllWebappConfig()
    {
        string physicalWebAppPath = "";
        AppSettingsSection appSettings;
        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
        physicalWebAppPath = System.Web.Hosting.HostingEnvironment.MapPath("~/webapp.config");
        if (System.IO.File.Exists(physicalWebAppPath))
        {
            fileMap.ExeConfigFilename = physicalWebAppPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            appSettings = (AppSettingsSection)config.GetSection("appSettings");
        }
        else
            appSettings = null;
        return appSettings;
    }
