    public static List<Func<T, object>> CreateAccessors<T>()
    {
        var accessors = new List<Func<T, object>>();
        Type t = typeof(T);
        foreach (PropertyInfo prop in t.GetProperties(BindingFlags.Instance | BindingFlags.Public)) {
            if (prop.CanRead) {
                var p = prop;
                accessors.Add(x => p.GetValue(x, null));
            }
        }
        return accessors;
    }
