    private IEnumerable<List<int>> FooSplit(IEnumerable<int> items)
    {
        List<int> source = new List<int>(items);
        while (source.Any())
        {
            var result = source.Distinct().ToList();
            yield return result;
            result.ForEach(item => source.Remove(item));
        }
    }
