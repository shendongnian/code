    IEnumerable<Dictionary<string, dynamic>> inputs1 = ....; // normal items
    IEnumerable<ILookup<string, dynamic>> inputs2 = ....; // items that previously already collided
    var allAsLookups =
        inputs1.ToLookup(pair => pair.Key, pair => pair.Value)
        .Concat( inputs2 );
    // btw. GropuBy returns a lookup, too :) a key -> all matches
    var matched_by_keys = lookups.GroupBy(lk => lk.Key);
    
    var final1 = matched_by_keys.ToDictionary(group => group.Key, group => group.SelectMany(s=>s));
