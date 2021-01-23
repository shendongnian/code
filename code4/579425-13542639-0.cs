    public static bool PropertiesEquals<T>(this T first, T other)
    {
        var propertyInfos = first.GetType().GetProperties();
        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            if (!Equals(propertyInfo.GetValue(first, null), propertyInfo.GetValue(other, null)))
                return false;
        }
        return true;
    }
