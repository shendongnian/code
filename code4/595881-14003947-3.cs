    public static IEnumerable<PropertyInfo> GetRuntimeProperties(this Type type)
    {
        CheckAndThrow(type);
        return type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public |
                                  BindingFlags.Static | BindingFlags.Instance);
    }
