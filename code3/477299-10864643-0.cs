    public static bool DoesTypeSupportInterface(Type type,Type inter)
    {
        if(inter.IsAssignableFrom(type))
            return true;
        if(type.GetInterfaces().Any(i=>i. IsGenericType && i.GetGenericTypeDefinition()==inter))
            return true;
        return false;
    }
