    Dictionary<string, int> counts = list1
      .Where(s => candidates.Contains(s))
      .GroupBy(s => s)
      .ToDictionary(g => g.Key, g => g.Count());
    
    List<string> missing = candidates
      .Where(s => !counts.ContainsKey(s))
      .ToList();
    List<string> tooMany = candidates
      .Where(s => counts.ContainsKey(s) && counts[s] != 1)
      .ToList();
