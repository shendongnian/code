    static double MaxOf(double[, ,] numbers, int? x = null, int? y = null, int? z = null)
    {
        var xs = x.HasValue ? Enumerable.Repeat(x.Value, 1) : Enumerable.Range(0, numbers.GetLength(0));
        var ys = y.HasValue ? Enumerable.Repeat(y.Value, 1) : Enumerable.Range(0, numbers.GetLength(1));
        var zs = z.HasValue ? Enumerable.Repeat(z.Value, 1) : Enumerable.Range(0, numbers.GetLength(2));
        return xs.Max(a => ys.Max(b => zs.Max(c => numbers[a, b, c])));
    }
