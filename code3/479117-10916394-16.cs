    public static IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, string separator = ",", header = true)
    {
        FieldInfo[] fields = typeof(T).GetFields();
        PropertyInfo[] properties = typeof(T).GetProperties();
        if (header)
        {
            yield return String.Join(separator, fields.Select(f => f.Name).Concat(properties.Select(p=>p.Name)).ToArray());
        }
        foreach (var o in objectlist)
        {
            yield return string.Join(separator, fields.Select(f=>(f.GetValue(o) ?? "").ToString())
                .Concat(properties.Select(p=>(p.GetValue(o,null) ?? "").ToString())).ToArray());
        }
    }
