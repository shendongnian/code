    public static object GetPropertyValue(object instance, string strPropertyName)
    {
        Type type = instance.GetType();
        System.Reflection.PropertyInfo propertyInfo = type.GetProperty(strPropertyName);
        return propertyInfo.GetValue(instance, null);
    }
