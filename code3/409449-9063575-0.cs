    public void UseLambda<T>(IEnumerable<T> source, Expression<Func<IEnumerable<T>, IEnumerable<T>>> expr)
    {
        var items = expr.Compile();
        foreach (var item in items.Invoke(source))
        {
            Console.WriteLine(item.ToString());
        }
    }
    public void Main()
    {
        Expression<Func<IEnumerable<int>, IEnumerable<int>>> expr = s => s.Where(n => n > 6).OrderBy(n => n % 2 == 0).Select(n => n);
        var list = new List<int> { 10, 24, 9, 87, 193, 12, 7, 2, -45, -2, 9 };
        UseLambda(list, expr);
    }
