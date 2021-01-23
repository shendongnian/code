    public static void SetPropertyValue(object instance, string strPropertyName, object newValue)
    {
        Type type = instance.GetType();
        System.Reflection.PropertyInfo propertyInfo = type.GetProperty(strPropertyName);
        propertyInfo.SetValue(instance, newValue, null);
    }
