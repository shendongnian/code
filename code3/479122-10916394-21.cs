    public static IEnumerable<string> ToCsv(string separator, IEnumerable<object> objectlist)
    {
        if (objectlist.Any())
        {
            Type type = objectlist.First().GetType();
            FieldInfo[] fields = type.GetFields();
            yield return String.Join(separator, fields.Select(f => f.Name).ToArray());
            foreach (var o in objectlist)
            {
                yield return string.Join(separator, fields.Select(f=>(f.GetValue(o) ?? "").ToString()).ToArray());
            }
        }
    }
