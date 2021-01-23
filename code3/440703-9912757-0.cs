    public static void MapTo<T, P>(
        this T source, T target, Expression<Func<T, P>> expr)
    {
        (expr.Body as NewExpression).Members.ToList()
            .ForEach(m => source.Copy(target, m.Name));
    }
    
    public static void Copy<T>(this T source, T target, string prop)
    {
        var p = typeof(T).GetProperty(prop);
        p.SetValue(target, p.GetValue(source, null), null);
    }
