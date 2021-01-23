    Dictionary<Type, Delegate> cache = new Dictionary<Type, Delegate>();
    public T Create<T>()
    {
        if (!cache.TryGetValue(typeof(T), out var d))
            d = cache[typeof(T)]
                = Expression.Lambda<Func<T>>(
                    Expression.New(typeof(T)),
                    Array.Empty<ParameterExpression>())
                .Compile();
        return ((Func<T>)d)();
    }
