    public static IEnumerable<T> MyMethod<T>(this IEnumerable<T> entity, 
                                   string param, Func<T, string> selector)
    {
        return entity.Where(l =>
        System.Data.Objects.SqlClient.SqlFunctions.PatIndex(param, selector(l)) > 0);
    }
