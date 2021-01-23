    public static IEnumerable<int> GetAscending(IEnumerable<int> input, int startIndex)
    {
        var ascending = input.Skip(startIndex)
            .Zip(input.Skip(startIndex + 1), (first, second) => new { Num = first, Next = second, Diff = second - first })
            .SkipWhile(p => p.Diff <= 0)
            .TakeWhile(p => p.Diff > 0)
            .Select(p => Tuple.Create(p.First, p.Second))
            .ToArray();
        if(ascending.Count == 0) return Enumerable.Empty<int>():
            
        return ascending.Select(t => t.Item1).Concat(new int[] { ascending.Last().Item2 });
    }
