    var PropCollection = type.GetProperties();
    foreach (PropertyInfo Property in PropCollection)
    {
        var value = DReader[Property.Name];
        if (!Property.GetType().IsAssignableFrom(value.GetType())
            value = Convert.ChangeType(value, Property.GetType());
    
        Property.SetValue(_t, value, null);
    }
