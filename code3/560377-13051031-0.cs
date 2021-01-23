    var instance = System.Activator.CreateInstance(Type.GetType(className));
    PropertyInfo[] properties = typeof(className).GetProperties();
    
    foreach (var property in properties)
    {
        property.SetValue(instance, session[property.Name], null);
    }
