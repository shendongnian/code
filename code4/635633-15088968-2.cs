    public static T GetAttributeValue<T> (this Entity e, string propertyName, T defaultValue = default(T))
    {
        if (e.Contains(propertyName))
        {
            return (T)e[propertyName];
        }
        else
        {
            return defaultValue;
        }
    }
