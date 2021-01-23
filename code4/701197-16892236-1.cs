    // Open App.Config of executable
    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    // Add an Application Setting.
    config.AppSettings.Settings.Remove("UserReportPath");
    config.AppSettings.Settings.Add("UserReportPath", txtUserReportPath.Text);
    // Save the configuration file.
    config.Save(ConfigurationSaveMode.Modified);
    // Force a reload of a changed section.
    ConfigurationManager.RefreshSection("appSettings");
