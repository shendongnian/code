    // get all the properties of "myObject"
    List<PropertyInfo> propertyInfoList = new List<PropertyInfo>(myObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public));
    // get the object's type and its base type
    Type objectType = objectToLog.GetType();
    Type baseType = objectToLog.GetType().BaseType;
    // if a baseType exists ...
    if (baseType != null)
    {
        // get the list of properties that are *not* defined directly in "myObject" - 
        // those are all the properties defined in the immediate and possible other base types
        List<PropertyInfo> baseProperties = propertyInfoList.Where(x => x.DeclaringType != objectType).ToList();
        
        // process those base properties
        
        // after processing, remove the base properties from the list of "all" properties to get just those
        // properties that are defined directly on the "myObject" type
        List<PropertyInfo> declaredProperties = propertyInfoList.Except(baseProperties);        
    }
