    public static IEnumerable<string> GetFields<T>()
    {
        Type type = typeof(T);
        return type.GetFields(BindingFlags.Static | BindingFlags.Public)
                    .Where(f => f.FieldType == typeof(string))
                    .Select(f => (string)f.GetValue(null));
    }
