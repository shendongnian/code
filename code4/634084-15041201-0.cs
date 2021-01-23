    public static Func<T, object[]> MakeFieldGetter<T>() {
        var arg = Expression.Parameter(typeof(T), "arg");
        var body = Expression.NewArrayInit(
            typeof(object)
        ,   typeof(T).GetFields().Select(f => (Expression)Expression.Convert(Expression.Field(arg, f), typeof(object)))
        );
       return (Func<T, object[]>)Expression
            .Lambda(typeof(Func<T, object[]>), body, arg)
            .Compile();
    }
