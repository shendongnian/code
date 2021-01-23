    var time = DateTime.Now.AddDays(-1);
    var c = scan.Entries;
    var first = BinaryFirstIndexOf(
         i => c[i], 
         e => e.TimeGenerated > time,
         c.Count);
    if (first >= 0)
    {
        var result = new List<Item>(c.Count - first);
        Enumerable.Range(first, c.Count - first).AsParallel()
        .ForAll(i => 
            {
                var j = i - first;
                result[j] = (Item)c[i];
            }
    }
    
