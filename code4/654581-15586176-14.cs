    public static IEnumerable<KeyValuePair<string,T>> PropertiesOfType<T>(object obj)
    {
        return from p in obj.GetType().GetProperties()
                where p.PropertyType == typeof(T)
                select new KeyValuePair<string,T>(p.Name, (T)p.GetValue(obj));
    }
