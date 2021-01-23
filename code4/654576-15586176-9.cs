    public static IEnumerable<KeyValuePair<string,string>> StringProperties(object obj)
    {
        return from p in obj.GetType().GetProperties()
                where p.PropertyType == typeof(string)
                select new KeyValuePair<string,string>(p.Name, (string)p.GetValue(obj));
    }
