    Dictionary<string, int> counts = candidates
     .GroupJoin(
       list1,
       c => c,
       s => s,
       (c, g) => new { Key = c, Count = g.Count()
     )
     .ToDictionary(x => x.Key, x => x.Count);
    
    List<string> missing = counts.Keys
      .Where(key => counts[key] == 0)
      .ToList();
    List<string> tooMany = counts.Keys
      .Where(key => 1 < counts[key])
      .ToList();
