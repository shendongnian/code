    public static bool AreAnyPropertiesNull(object obj)
    {
        foreach (var prop in obj.GetType().GetProperties())
        {
            object propertyValue = prop.GetValue(obj, null);
            if (propertyValue == null)
                return true;
        }
        return false;
    }
