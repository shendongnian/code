    Type type = obj.GetType();
    BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
    PropertyInfo[] properties = type.GetProperties(flags);
    
    foreach (PropertyInfo property in properties)
    {
        Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null));
    }
