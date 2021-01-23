    Type myType = Type.GetType(className);
    var instance = System.Activator.CreateInstance(myType);
    PropertyInfo[] properties = myType.GetProperties();
    
    foreach (var property in properties)
    {
        property.SetValue(instance, session[property.Name], null);
    }
