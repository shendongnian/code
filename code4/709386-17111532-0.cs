    public static IEnumerable<T> MyMethod<T>(this IEnumerable<T> entity, 
                                             string param, 
                                             params Func<T, string>[] selectors)
    {
        ...
    }
