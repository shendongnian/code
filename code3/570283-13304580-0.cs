    static void Main() {
        Expression<Func<int?>> x = () => 1, y = () => null;
        Expression<Func<int>> a = DeNullify(x), b = DeNullify(y);
        Console.WriteLine(x.Compile()()); // 1
        Console.WriteLine(y.Compile()()); // {blank; null}
        Console.WriteLine(a.Compile()()); // 1
        Console.WriteLine(b.Compile()()); // 0 
    }
    public static Expression<Func<TValue>> DeNullify<TValue>(
        Expression<Func<TValue?>> expression) where TValue : struct
    {
        return Expression.Lambda<Func<TValue>>(
            Expression.Call(expression.Body, "GetValueOrDefault", null),
            expression.Parameters);
    }
