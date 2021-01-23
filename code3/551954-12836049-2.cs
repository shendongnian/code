    PropertyInfo[] properties = viewModelInstance.GetType().GetProperties();
    foreach (PropertyInfo property in properties)
    {
        var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) 
            as KeyAttribute;
    
        if (attribute != null) // This property has a KeyAttribute
        {
             // Do something, to read from the property:
             object val = property.GetValue(viewModelInstance);
        }
    }
