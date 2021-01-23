    public static bool SetValueTypes(object instance, IEnumerable<Value> values){
        var mappedProperties = instance.GetType()
                                   .GetProperties()
                                   .Where(type => type.GetCustomAttributes(typeof(CustomAttribute), true).Length > 0);
        foreach (PropertyInfo property in mappedProperties)
        {
           /*...and then some code to get the Value to set in the property*/
           var value = GetValue(values);
           property.SetValue(instance, value, null);
        }
        var complexProperties = instance.GetType()
                                   .GetProperties()
        // Either assume that unmapped properties are all complex,
        // or use your own criteria. Maybe anything whose type is
        // a class and not a string?
                                   .Where(type => type.GetCustomAttributes(typeof(CustomAttribute), true).Length == 0);
        foreach (PropertyInfo property in mappedProperties)
        {
           var value = Activator.CreateInstance(property.PropertyType);
           SetValueTypes(value, values);
           property.SetValue(instance, value, null);
        }
    }
