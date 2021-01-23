    public static IEnumerable<TempTable> DFS(IEnumerable<TempTable> list, int? ParentID = null)
    {
        var lkp = list.ToLookup(x => x.ParentID, x => x);
        var stck = new Stack<int?>();
        stck.Push(ParentID);
        while (stck.Count > 0)
        {
            var pid = stck.Pop();
            foreach (var p in lkp[pid].OrderBy(x => x.SortOrder))
            {
                yield return p;
                stck.Push(p.ID);
            }
        }
    }
