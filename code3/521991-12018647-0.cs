    public static PropertyInfo[] GetPropertiesUpTo<T>(this Type type, BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)
    {
        return type.GetProperties(flags)
                   .Where(p => p.DeclaringType == typeof(T) || p.DeclaringType.IsSubclassOf(typeof(T)))
                   .ToArray();
    }
