    public static void PrintPossibilities<T>(IExpression<T> expression)
    {
        Console.WriteLine(string.Join(" + ", expression.Possibilities()
                .Select(possibility =>
                    string.Concat(possibility.Select(value => value.Value)))));
    }
