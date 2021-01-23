    public static T CloneExcept<T, S>(this T target, S source, string[] propertyNames)
    {
        if (source == null)
        {
            return target;
        }
        Type sourceType = typeof(S);
        Type targetType = typeof(T);
        BindingFlags flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
        PropertyInfo[] properties = sourceType.GetProperties();
        foreach (PropertyInfo sPI in properties)
        {
            if (!propertyNames.Contains(sPI.Name))
            {
                PropertyInfo tPI = targetType.GetProperty(sPI.Name, flags);
                if (tPI != null && tPI.PropertyType.IsAssignableFrom(sPI.PropertyType))
                {
                    tPI.SetValue(target, sPI.GetValue(source, null), null);
                }
            }
        }
        return target;
    }
