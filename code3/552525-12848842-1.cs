    private static readonly MethodInfo ToStrongListMethod = typeof(...)
        .GetMethod("ToStrongListImpl", BindingFlags.Static | BindingFlags.NonPublic);
    public static IList ToStrongList(this IEnumerable source, Type targetType)
    {
        var method = ToStrongListMethod.MakeGenericMethod(targetType);
        return (IList) method.Invoke(null, new object[] { source });
    }
    private static List<T> ToStrongListImpl<T>(this IEnumerable source)
    {
        return source.Cast<T>().ToList();
    }
