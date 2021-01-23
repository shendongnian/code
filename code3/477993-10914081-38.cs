    public static IEnumerable<ILookup<TKey[], TValue>> GroupCombined<TKey, TValue>(List<TKey> keys,
                                                                                   List<TValue> values)
    {
        foreach (int i in Enumerable.Range(1, keys.Count))
        {
            foreach (ILookup<int, TKey> lookup in Group(Enumerable.Range(0, i).ToList(), keys))
            {
                foreach (ILookup<TKey[], TValue> lookup1 in Group(lookup.Select(keysComb => keysComb.ToArray()).ToList(), values))
                {
                    yield return lookup1;
                }
            }
        }
    }
