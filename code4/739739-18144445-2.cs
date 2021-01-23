    public static IEnumerable<TempTable> DFS(IEnumerable<TempTable> list = null, int? ParentID = null, ILookup<int?, TempTable> lkp = null)
    {
        if (lkp == null)
            lkp = list.ToLookup(x => x.ParentID, x => x);
        foreach (var p in lkp[ParentID].OrderBy(x => x.SortOrder))
        {
            yield return p;
            foreach (var c in DFS(null, p.ID, lkp))
                yield return c;
        }
    }
