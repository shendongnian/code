    public static IQueryable<MyType> Filter(this IQueryable<MyType> query, string param, Func<MyType, string> predicate)
    {
        var req = query.Where(c =>
            (!(param == null || param.Trim() == "") && predicate(c).StartsWith(param))
                || ((param == null || param.Trim() == "")));
        return req;
    }
