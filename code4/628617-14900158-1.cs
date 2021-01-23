    public static IList ToList(this IEnumerable source, string typeName)
    {
        return ToList(source, Type.GetType(typeName));
    }
    public static IList ToList(this IEnumerable source, Type type)
    {
        var list = (IList)Activator.CreateInstance(
            typeof(List<>).MakeGenericType(type));
        foreach(object item in source) list.Add(item);
        return list;
    }
