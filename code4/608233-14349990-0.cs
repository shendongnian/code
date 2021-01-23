    using System.Configuration;
  
    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    var connectionStrings = config.ConnectionStrings;
    foreach (var connectionString in connectionStrings.ConnectionStrings)
    {
        // change connection details
    }
    config.Save(ConfigurationSaveMode.Modified);
