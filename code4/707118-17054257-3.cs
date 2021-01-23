    private static object FormatDateTime(object x)
    {
        if (x == null || x is IEnumerable)
            return x;
        var t = x.GetType();
        if (t == typeof(DateTime))
            return ((DateTime)x).ToString("g");
        if (t.IsPrimitive)
            return x;
        var result = new Dictionary<string, object>();
        foreach (var prop in t.GetProperties())
        {
            // Skip properties with ScriptIgnoreAttribute
            if (prop.GetCustomAttributes(typeof(ScriptIgnoreAttribute), true).Any())
                continue;
            result[prop.Name] = FormatDateTime(prop.GetValue(x, null));
        }
        return result;
    }
