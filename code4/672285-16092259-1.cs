    public static void SetProperty(dynamic propertyBag, string propertyName, object value)
    {
        PropertyInfo property = propertyBag.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (property == null)
        {
            throw new NotImplementedException();
        }
        MethodInfo setProperty = property.GetSetMethod();
        setProperty.Invoke(propertyBag, new object[] { value });
    }
