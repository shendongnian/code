    public bool Compare<T>(T[] first, T[] second) {
        var firstItemCounts = first.GroupBy(x => x)
                                   .ToDictionary(g => g.Key, g => g.Count());
        var secondItemCounts = second.GroupBy(x => x)
                                     .ToDictionary(g => g.Key, g => g.Count());
        foreach(var key in firstItemCounts.Keys.Union(secondItemCounts.Keys)) {
            if(!firstItemCounts.ContainsKey(key) ||
                   !secondItemCounts.ContainsKey(key)
            ) {
                return false;
            }
            if(firstItemCounts[key] != secondItemCounts[key]) {
                return false;
            }
        }
        return true;
    }
     
