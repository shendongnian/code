    static IEnumerable<double> GetTopValues(this IEnumerable<double> values, int count)
    {
        var maxSet = new List<double>(Enumerable.Repeat(double.MinValue, count));
        var currentMin = double.MinValue;
        foreach (var t in values)
        {
            if (t <= currentMin) continue;
            maxSet.Remove(currentMin);
            maxSet.Add(t);
            currentMin = maxSet.Min();
        }
        return maxSet.OrderByDescending(i => i);
    }
