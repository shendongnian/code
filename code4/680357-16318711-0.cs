    private void GetProperties<T>(T instance)
    {
        GetProperties(typeof(T), instance);
    }
    
    private void GetProperties(Type classType, object instance)
    {
        foreach (PropertyInfo property in classType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            WriteToLog(property.Name + ": " + property.PropertyType + ": " + property.MemberType);
            object value = property.GetValue(instance, null);
            if (value != null) {
                WriteToLog(value.ToString());
                GetProperties(property.PropertyType, value);
            }
        }
    }
