    Outlook.UserProperties properties = appointmentItem.UserProperties;
    Outlook.UserProperty property = null;
    try
    {
        property = properties.Add(propertyName, Outlook.OlUserPropertyType.olText);
    }
    catch (System.UnauthorizedAccessException exception)
    {
        // the first time didn't work, try again once before giving up
        property = properties.Add(propertyName, Outlook.OlUserPropertyType.olText);
    }
