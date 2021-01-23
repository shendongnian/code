    private static readonly Func<T, T, T> adder;
    static NumberContainer() {
        var p1 = Expression.Parameter(typeof (T));
        var p2 = Expression.Parameter(typeof (T));
        adder = (Func<T, T, T>)Expression
            .Lambda(Expression.Add(p1, p2), p1, p2)
            .Compile();
    } 
    public T Total { get { return adder(ValueA, ValueB); } }
