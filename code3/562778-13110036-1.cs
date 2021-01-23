    var allArrays = new[]
    {
        new[] { 1, 202, 4, 55 },
        new[] { 40, 7 },
        new[] { 2, 48, 5 },
        new[] { 40, 8, 90 }
    };
    
    // Find the indexes to compare
    // Exclude i=3, because there is nothing to compare,
    // i.e. only 55 in the 1st array
    
    var maxElementsCount = allArrays.GroupBy(p => p.Length)
        // Find 2 at least
        .Where(p => p.Count() > 1)
        // Get the maximum
        .OrderByDescending(p => p.Count())
        .First().Key;
    
    // 0, 1, 2
    var indexes = Enumerable.Range(0, maxElementsCount);
    
    // Get the slices
    var slices = indexes.Select(i =>
        allArrays.Select((array, arrayNo) => new
        {
            ArrayNo = arrayNo,
            Value = i < array.Length ? array[i] : (int?)null
        }))
        .ToArray();
