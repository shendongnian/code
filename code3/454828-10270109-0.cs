    public static double[] GenerateRandomOrderedNumbers(int count)
    {
        var random = new Random();
        return Enumerable.Range(0, count)
            .Select(i => random.NextDouble())
            .OrderBy(d => d)
            .ToArray();
    }
