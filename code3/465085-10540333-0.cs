    public static bool IsType(Type type, Type ancestor)
    {
        while (type != null)
        {
            if (type.IsGenericType)
                type = type.GetGenericTypeDefinition();
            if (type == ancestor)
                return true;
            type = type.BaseType;
        }
        return false;
    }
