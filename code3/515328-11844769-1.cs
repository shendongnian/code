    Configuration exeConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    ConfigurationSection diagnosticsSection = exeConfiguration.GetSection("system.diagnostics");
    
    ConfigurationElementCollection switches = diagnosticsSection.ElementInformation
                                                                .Properties["switches"]
                                                                .Value as ConfigurationElementCollection;
    
    foreach (ConfigurationElement switchElement in switches)
    {
        Debug.WriteLine("switch: name=" + 
            switchElement.ElementInformation.Properties["name"].Value +
            " value=" + 
            switchElement.ElementInformation.Properties["value"].Value);
    }
