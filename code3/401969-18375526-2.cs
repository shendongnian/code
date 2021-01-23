    public static IEnumerable<Type> GetParentTypes(this Type type)
    {
        // null does not have base type
        if (type == null)
        {
            return Enumerable.Empty<Type>();
        }
        // return all implemented or inherited interfaces
        foreach (var i in type.GetInterfaces())
        {
            yield i;
        }
        // return all inherited types
        var currentBaseType = type.BaseType;
        while (currentBaseType != null)
        {
            yield currentBaseType;
            currentBaseType= currentBaseType.BaseType;
        }
    }
