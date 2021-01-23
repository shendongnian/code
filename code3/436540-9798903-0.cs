    private static readonly ConcurrentDictionary<Tuple<Type, string>, Action> MethodCache =
        new ConcurrentDictionary<Tuple<Type, string>, Action>();
    public static void Run<T>(string method)
    {
        // Calls static parameterless methods on any type
        var act = MethodCache.GetOrAdd(
            Tuple.Create(typeof (T), method),
            v =>
                {
                    var mi = v.Item1.GetMethod(
                        v.Item2, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    return (Action) Expression.Lambda(Expression.Call(mi)).Compile();
                });
        act();
    }
