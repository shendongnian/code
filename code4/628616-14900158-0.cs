    public static IList ToList(this IEnumerable source, string typeName)
    {
        return ToList(source, Type.GetType(typeName));
    }
    public static IList ToList(this IEnumerable source, Type type)
    {
        return (IList)Activator.CreateInstance(
            typeof(List<>).MakeGenericType(type));
    }
