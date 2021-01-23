    var tableFromIndex = ParallelEnumerable.Range(2, size - 2)
            .AsOrdered()
            .Select(i => Func(i).Count());
    
    return new[] { 0, 1 }
            .Concat(tableFromIndex)
            .ToArray();
