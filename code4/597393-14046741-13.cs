    var parents = (from p in mainList
                   where !p.Leaf
                   select p).ToDictionary(p => p.State, p => p);
    var leaves = (from l in mainList
                  where l.Leaf
                  group l by l.State into stateGroup
                  select stateGroup).ToDictionary(g => g.Key, g => g.ToList());
    foreach (var l in leaves.Keys)
    {
        if (parents.ContainsKey(l))
            parents[l].Leaves = leaves[l];
    }
    return JsonConvert.SerializeObject(parents.Select(p => p.Value).ToList());
