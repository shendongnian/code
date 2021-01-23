    var custom = (MyCustomSection)ConfigurationManager.GetSection("MyCustomSection");
    foreach (MyItemType itemType in custom.MyItems)
    {
        if (itemType.FirstSubTypeConfig.ElementInformation.IsPresent 
            && itemType.SecondSubTypeConfig.ElementInformation.IsPresent)
        {
            throw new ConfigurationErrorsException("At most one of firstSubTypeConfig or secondSubTypeConfig can be specified in a myItemType element");
        }
        else if (!itemType.FirstSubTypeConfig.ElementInformation.IsPresent
            && !itemType.SecondSubTypeConfig.ElementInformation.Ispresent)
        {
            throw new ConfigurationErrorsException("Either a firstSubTypeConfig or a secondSubTypeConfig element must be specified in a myItemType element");
        }
    }
