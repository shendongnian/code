    public static IEnumerable<string> GetPropertyNames(string className)
    {
        Type type = Type.GetType(className);
        return type.GetProperties().Select(p => p.Name);
    }
