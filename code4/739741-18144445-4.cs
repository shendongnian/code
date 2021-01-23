    public static IEnumerable<TempTable> SortedList(IEnumerable<TempTable> list = null, int? ParentID = null, ILookup<int?, TempTable> lookup = null)
    {
        if (lookup == null)
            lookup = list.ToLookup(x => x.ParentID, x => x);
        foreach (var p in lookup[ParentID].OrderBy(x => x.SortOrder))
        {
            yield return p;
            foreach (var c in SortedList(lookup: lookup, ParentID: p.ID))
                yield return c;
        }
    }
