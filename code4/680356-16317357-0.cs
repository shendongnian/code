    private void GetProperties<T>()
    {
    	GetProperties(typeof(T));
    }
    
    private void GetProperties(Type classType)
    {
        foreach (PropertyInfo property in classType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            WriteToLog(property.Name + ": " + property.PropertyType + ": " + property.MemberType);
            GetProperties(property.PropertyType);
        }
    }
