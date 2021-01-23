    using (var context = new TestDBEntities())
    {
        var path = "foo/bar/baz";
        var parts = new LinkedList<string>(path.Split('/'));
        var table = context.TestTrees;
        var code = parts.First.Value;
        var root = table.Where(r1 => r1.Code == code && !r1.ParentID.HasValue);
        parts.RemoveFirst();
        foreach (var q in root.Traverse(table, parts))
            Console.WriteLine("{0} {1} {2}", q.ID, q.ParentID, q.Code);
    }
