    var buckets = myArray.GroupBy(n => n)
                         .ToDictionary(g => g.Key, g => g.Count());
    var rangeCounts = 
        buckets.Keys
               .Select(v =>
                   new {
                       Value = v,
                       Count = Enumerable.Range(0, 6)
                                         .Sum(i => buckets.ContainsKey(v + i) ? 
                                                   buckets[v + i] : 
                                                   0
                                             )
                   }
        );
    var bestRange = rangeCounts.MaxBy(x => x.Count);
    
