    public static IEnumerable<FieldInfo> GetAllFields(this Type type)
    {
        IEnumerable<FieldInfo> fields = type.GetFields(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (type.BaseType == null)
            return fields;
        else
            return GetAllFields(baseType).Concat(fields);
    }
