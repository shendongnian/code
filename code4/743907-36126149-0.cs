    using System.Reflection;
    ...
    
    Configuration config = ConfigurationManager.OpenExeConfiguration(
        Assembly.GetExecutingAssembly().Location);
    
    KeyValueConfigurationElement element = config.AppSettings.Settings["Names"];
    
    string names = null;
    if (element != null)
        names = element.Value;
