    ExeConfigurationFileMap map = new ExeConfigurationFileMap();
    map.ExeConfigFilename = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~"), "web.config"); // the root web.config  
    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
    var group = ServiceModelSectionGroup.GetSectionGroup(config);
    foreach (EndpointBehaviorElement item in group.Behaviors.EndpointBehaviors)
    {
        // TODO: add code...
    }
