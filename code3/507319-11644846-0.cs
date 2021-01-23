    private void changeValue(String KeyName, String KeyValue)
    {
    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    // Update the setting.
    config.AppSettings.Settings[KeyName].Value = KeyValue;
    
    // Save the configuration file.
    config.Save(ConfigurationSaveMode.Modified);
    
    // Force a reload of the changed section.
    ConfigurationManager.RefreshSection("appSettings");
    }
