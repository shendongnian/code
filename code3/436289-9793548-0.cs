    public static IEnumerable<Type> GetDeclaredInterfaces(this Type t)
    {
        var allInterfaces = t.GetInterfaces();
        var baseInterfaces = Enumerable.Empty<Type>();
        if (t.BaseType != null)
        {
            baseInterfaces = t.BaseType.GetInterfaces();
        }
        return allInterfaces.Except(baseInterfaces);
    }
