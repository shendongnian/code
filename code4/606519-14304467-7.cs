    private IEnumerable<IEnumerable<int>> FooSplit(IEnumerable<int> items)
    {
        var groups = items.GroupBy(i => i).Select(g => g.ToList()).ToList();    
    
        while (groups.Count > 0)
        {
           yield return groups.Select( g => 
                 { var i = g[0]; g.RemoveAt(g.Count - 1); return i; });
           groups.RemoveAll(g => g.Count == 0);
        }
    }
