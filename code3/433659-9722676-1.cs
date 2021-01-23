    public static void SetValue<T>(T obj, string propertyName, object value)
    {
        // these should be cached if possible
        Type type = typeof(T);
        PropertyInfo pi = type.GetProperty(propertyName);
        pi.SetValue(obj, Convert.ChangeType(value, pi.PropertyType), null);
    }
