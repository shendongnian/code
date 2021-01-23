    public static IEnumerable<Type> getBaseTypes(Type type)
    {
        yield return type;
    
        Type baseType = type.BaseType;
        while (baseType != null)
        {
            yield return baseType;
            baseType = baseType.BaseType;
        }
    }
