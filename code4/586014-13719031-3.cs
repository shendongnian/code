    public static Type[] GetClosingArguments<T>(this Type type)
    {
        Type iType = typeof(T).GetInterfaces()
                              .FirstOrDefault(i => i.IsGenericType &&
                                                   i.GetGenericTypeDefinition() == type);
        if (iType == null)
            return null;
        else
            return iType.GetGenericArguments();
    }
