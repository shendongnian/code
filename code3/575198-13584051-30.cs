    public static IQueryable<TestTree> Traverse(this IQueryable<TestTree> source, IQueryable<TestTree> table, LinkedList<string> parts)
    {
        var code = parts.First.Value;
        var query = source.SelectMany(r1 => table.Where(r2 => r2.Code == code && r2.ParentID == r1.ID), (r1, r2) => r2);
        if (parts.Count == 1)
        {
            return query;
        }
        parts.RemoveFirst();
        return query.Traverse(table, parts);
    }
