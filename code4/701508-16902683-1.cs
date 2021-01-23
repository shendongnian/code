    public IEnumerable<bool?> DecisionMatrix(this IEnumerable<bool?> source, IEnumerable<IEnumerable<bool?>> options)
    {
        IList<bool?> sourceList = source.ToList();
        return options.Where(n => n.Count() == sourceList.Count)
            .Select(n => n.Select((x, i) => new {Value = x, Index = i}))
            .Where(n => 
                n.All(n => !(sourceList[n.Index] ^ n.Value ?? sourceList[n.Index])))
            .FirstOrDefault();
    }
