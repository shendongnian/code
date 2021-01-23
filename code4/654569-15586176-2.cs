    public static IEnumerable<string> StringProperties(object obj)
    {
        return from p in obj.GetType().GetProperties()
                where p.PropertyType == typeof(string)
                select (string)p.GetValue(obj);
    }
