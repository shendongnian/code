    public static IEnumerable<string> ToCsv<T>(string separator, IEnumerable<T> objectlist)
    {
        FieldInfo[] fields = typeof(T).GetFields();
        PropertyInfo[] properties = typeof(T).GetProperties();
        yield return String.Join(separator, fields.Select(f => f.Name).Union(properties.Select(p=>p.Name)).ToArray());
        foreach (var o in objectlist)
        {
            yield return string.Join(separator, fields.Select(f=>(f.GetValue(o) ?? "").ToString())
                .Union(properties.Select(p=>(p.GetValue(o,null) ?? "").ToString())).ToArray());
        }
    }
