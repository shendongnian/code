    // Iterates through every item in a multidementional array array
    private Array MutateArray<T>(Array a, Func<T, int[], T> selector)
    {
        var rank = a.Rank;
        var lengths = Enumerable.Range(0, a.Rank)
                                .Select(r => a.GetLength(r))
                                .ToArray(); // Get length of a in each dimension
        var result = Array.CreateInstance(typeof(T), lengths);
        var index = new int[a.Rank];
        foreach (T item in a) // flattens array
        {
            result.SetValue(selector(item, index), index);
            // Get next index value (I'm sure this could be improved)
            for (var d = 0; d < rank; d++)
            {
                if (index[d] == lengths[d] - 1)
                {
                    index[d] = 0;
                }
                else
                {
                    index[d]++;
                    break;
                }
            }
        }
        return result;
    }
    // Your "foo" method
    private double[,] generic_foo(double[,] a, int d)
    {
        var upperD = a.GetUpperBound(d);
        return (double[,])MutateArray<double>(a, (x, i) =>
        {
            var prev = i.ToArray(); // clone
            prev[d] = Math.Max(prev[d] - 1, 0);
            var next = i.ToArray(); // clone
            next[d] = Math.Min(next[d] + 1, upperD);
            var prevVal = (double)a.GetValue(prev);
            var nextVal = (double)a.GetValue(next);
            return (nextVal - prevVal) * 0.5;
        });
    }
