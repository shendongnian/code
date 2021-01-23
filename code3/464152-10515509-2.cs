    var allValues = new List<string>() { "A1", "A2", "A3", "B1", "B2", "C1" };
    List<String> result = new List<String>();
    var indices = Enumerable.Range(1, allValues.Count);
    foreach (int lowerIndex in indices)
    {
        var partVariations = new Facet.Combinatorics.Variations<String>(allValues, lowerIndex);
        result.AddRange(partVariations.Select(p => String.Join(" ", p)));
    }
    var length = result.Count;  // 1956
