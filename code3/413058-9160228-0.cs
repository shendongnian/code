    static public bool HasProperty(this Type type, string name)
    {
        return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Any(p => p.Name == name);
    }
