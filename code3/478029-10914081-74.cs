    public static IEnumerable<ILookup<TKey[], TValue>> GroupCombined<TKey, TValue>
        (List<TKey> keys,
         List<TValue> values)
    {
        for (var i = 1; i <= keys.Count; i++)
        {
            var prevs = new List<TKey[][]>();
            foreach (var lookup in Group(Enumerable.Range(0, i).ToList(), keys))
            {
                var found = false;
                var curr = lookup.Select(sub => sub.OrderBy(k => k).ToArray())
                    .OrderBy(arr => arr.FirstOrDefault()).ToArray();
                foreach (var prev in prevs.Where(prev => prev.Length == curr.Length))
                {
                    var isDuplicate = true;
                    for (var x = 0; x < prev.Length; x++)
                    {
                        var currSub = curr[x];
                        var prevSub = prev[x];
                        if (currSub.Length != prevSub.Length ||
                            !currSub.SequenceEqual(prevSub))
                        {
                            isDuplicate = false;
                            break;
                        }
                    }
                    if (isDuplicate)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    continue;
                }
                prevs.Add(curr);
                foreach (var group in
                         Group(lookup.Select(keysComb => keysComb.ToArray()).ToList(),
                               values))
                {
                    yield return group;
                }
            }
        }
    }
