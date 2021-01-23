    var matches = new List<int[]>();
    for (int i = 0; i < input.Length; i++)
    {
        // Compare with all the next arrays
        // "j = i + 1", to do not compare twice
        for (int j = i + 1; j < input.Length; j++)
        {
            var match = input[i].Intersect(input[j]).ToArray();
            if (match.Length > 1) // The smallest group contains 2 elements 
            {
                matches.Add(match);
            }
        }
    }
    var comparer = new ArrayComparer<int>();
    var mostCommon = matches
        .GroupBy(p => p, comparer)
        // Sort by frequency
        .OrderByDescending(p => p.Count())
        // Sort by the group's length
        .ThenByDescending(p => p.Key.Count())
        .FirstOrDefault();
