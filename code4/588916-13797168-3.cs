    var propertyName = "ViewA";
    var propertyFound = type.GetProperty(propertyName, BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    if(propertyFound != null)
    {
        return propertyFound.GetValue(instance, null);
    }
