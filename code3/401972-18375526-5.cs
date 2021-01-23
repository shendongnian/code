    public static bool InheritsFrom(this Type type, Type baseType)
    {
        // null does not have base type
        if (type == null)
        {
            return false;
        }
        // only interface or object can have null base type
        if (baseType == null)
        {
            return type.IsInterface || type == typeof(object);
        }
        // check implemented interfaces
        if (baseType.IsInterface)
        {
            return type.GetInterfaces().Contains(baseType);
        }
        // check all base types
        var currentType = type;
        while (currentType != null)
        {
            if (currentType.BaseType == baseType)
            {
                return true;
            }
            currentType = currentType.BaseType;
        }
        return false;
    }
