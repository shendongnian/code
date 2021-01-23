    public static IEnumerable<T> Columns<T>(this IEnumerable<T> input, int cols)
    {
        if (cols < 1)
        {
            throw new ArgumentOutOfRangeException(...);
        }
        var m = input.Count() / cols;
        return input.Select((x, i) => new { x, i })
                    .OrderBy(p => p.i % m)
                    .Select(p => p.x);
    }
    // Usage
    var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var sorted = input.Columns(2); // { 1, 6, 2, 7, 3, 8, 4, 9, 5, 10 }
