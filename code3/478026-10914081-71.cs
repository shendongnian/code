    public static IEnumerable<ILookup<TKey[], TValue>> GroupCombined<TKey, TValue>
        (List<TKey> keys,
         List<TValue> values)
    {
        // foreach (int i in Enumerable.Range(1, keys.Count))
        for (var i = 1; i <= keys.Count; i++)
        {
            foreach (var lookup in Group(Enumerable.Range(0, i).ToList(), keys))
            {
                foreach (var lookup1 in
                         Group(lookup.Select(keysComb => keysComb.ToArray()).ToList(),
                               values))
                {
                    yield return lookup1;
                }
            }
        }
        /*
        Same functionality:
        return from i in Enumerable.Range(1, keys.Count)
               from lookup in Group(Enumerable.Range(0, i).ToList(), keys)
               from lookup1 in Group(lookup.Select(keysComb =>
                                         keysComb.ToArray()).ToList(),
                                     values)
               select lookup1;
        */
    }
