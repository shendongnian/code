    public static IEnumerable<Type> GetClassHierarchy(Type type)
    {
        while (type != null)
        {
            yield return type;
            type = type.BaseType;
        }
    }
