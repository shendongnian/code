    static T UnboxUnchecked<T>(object obj) {
        var pe = Expression.Parameter(typeof(object));
        return Expression.Lambda<Func<object,T>>(
            Expression.Convert(
                Expression.Convert(pe, obj.GetType())
            ,   typeof (T)
            )
        ,   pe
        ).Compile()(obj);
    }
