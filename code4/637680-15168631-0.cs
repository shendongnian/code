    // To Save
    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    config.AppSettings.Settings["Username"].Value = "NewValue";
    config.AppSettings.SectionInformation.ForceSave = true;
    config.Save(ConfigurationSaveMode.Modified);
    
    // To Refresh
    ConfigurationManager.RefreshSection("appSettings");
    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
