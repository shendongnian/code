    public void AddPropertiesAndChildPropertiesToList(Type type, List<PropertyInfo> list)
    {
        var properties = type.GetProperties();
        list.AddRange(properties);
        foreach (var property in properties)
        {
            // recursive methods are ones that call themselves, like this...
            AddPropertiesAndChildPropertiesToList(property.PropertyType, list);
        }
    }
