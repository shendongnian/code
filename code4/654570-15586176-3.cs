    public static IEnumerable<T> PropertiesOfType<T>(object obj)
    {
        return from p in obj.GetType().GetProperties()
                where p.PropertyType == typeof(T)
                select (T)p.GetValue(obj);
    }
