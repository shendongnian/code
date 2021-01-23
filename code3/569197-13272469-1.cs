    public static Dictionary<Header, Detail> Ungroup(Dictionary<Header, Detail> input)
    {
        var output = new Dictionary<Header, Detail>();
    
        foreach (var key in input.Keys)
        {
            var lookup = input[key].Parts.ToLookup(part => part);
    
            bool done = false;
    
            for (int i = 0; !done; i++)
            {
                var parts = lookup.GetNthValues(i).ToList();
                if (parts.Any())
                {
                    output.Add(new Header(key.Value), new Detail { Parts = parts });
                }
                else
                {
                    done = true;
                }
            }
        }
    
        return output;
    }
    
    public static IEnumerable<TElement> GetNthValues<TKey, TElement>(
        this ILookup<TKey, TElement> source, int n)
    {
        foreach (var group in source)
        {
            if (group.Count() > n)
            {
                yield return group.ElementAt(n);
            }
        }
    }
