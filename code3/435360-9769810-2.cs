    public static Expression<Func<T, bool>>
    Build(string propertyName, string method, params object[] args) 
    {
        var propertyInfo = typeof(T).GetProperty(propertyName);
        var e = Expression.Parameter(typeof(T), "e");
        var m = Expression.MakeMemberAccess(e, propertyInfo);
        var mi = m.Type.GetMethod(method, args.Select(a => a.GetType()).ToArray());
        var c = args.Select(a => Expression.Constant(a, a.GetType())).ToArray();
        Expression call = Expression.Call(m, mi, c);
        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, e);
        return lambda;
    }
