    object GetValueFromClassProperty(string propname, object instance)
    {
        var type = instance.GetType();
        foreach (var property in type.GetProperties())
        {
            var value = property.GetValue(instance, null);
            if (property.PropertyType.FullName != "System.String"
                && !property.PropertyType.IsPrimitive)
            {
                return GetValueFromClass(propname, value);
            }
            else if (property.Name == propname)
            {
                return value;
            }
        }
    
        // if you reach this point then the property does not exists
        return null;
    }
