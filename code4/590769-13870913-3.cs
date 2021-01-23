    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    var custom = (MyCustomSection)config.GetSection("MyCustomSection");
    //make modifications against the custom variable ...
    foreach (MyItemType itemType in custom.MyItems)
    {
        if (!itemType.FirstSubTypeConfig.ElementInformation.IsPresent)
            itemType.FirstSubTypeConfig = null;
        if (!itemType.SecondSubTypeConfig.ElementInformation.IsPresent)
            itemType.SecondSubTypeConfig = null;  
    }
    config.Save();
