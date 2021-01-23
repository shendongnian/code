    public static Type[] GetClosingArguments(this Type type, Type baseGenericType)
    {
        Type iType = type.GetInterfaces()
                         .FirstOrDefault(i => i.IsGenericType &&
                                   i.GetGenericTypeDefinition() == baseGenericType);
        if (iType == null)
            return null;
        else
            return iType.GetGenericArguments();
    }
