    public static IEnumerable<T> MyMethod<T>(this IEnumerable<T> entity, 
                                             string param, 
                                             params Func<T, string>[] selectors)
    {
        foreach(var selector in selectors)
        {
            entity = entity.Where(l => 
                SqlFunctions.PatIndex(param, selector(l)) > 0);
        }
        return entity;
    }
