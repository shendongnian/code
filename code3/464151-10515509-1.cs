    var allValues = new List<string>() { "A1", "A2", "A3", "B1", "B2", "C1" };
    List<String> result = new List<String>();
    var range = Enumerable.Range(1, allValues.Count);
    foreach (int numItems in range)
    {
        var partPermutations = new Facet.Combinatorics.Variations<String>(allValues, numItems);
        result.AddRange(partPermutations.Select(p => String.Join(" ", p)));
    }
    var length = result.Count;  // 1956
