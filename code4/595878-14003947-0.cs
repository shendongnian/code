    public static PropertyInfo GetRuntimeProperty(this Type type, string name)
    {
        CheckAndThrow(type);
        return type.GetProperty(name);
    }
