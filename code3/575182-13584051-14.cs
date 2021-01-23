    static TestTree GetNode(this IEnumerable<TestTree> table, string[] parts, int index, int? parentID)
    {
        var q = table
            .Where(r => 
                 r.Code == parts[index] && 
                 (r.ParentID.HasValue ? r.ParentID == parentID : parentID == null))
            .Single();
        return index < parts.Length - 1 ? table.GetNode(parts, index + 1, q.ID) : q;
    }
