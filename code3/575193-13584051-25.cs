    using (var context = new TestDBEntities())
    {
        var path = "foo/bar/baz";
        var parts = path.Split('/');
        var q = context
            .TestTrees
            .Where(r => parts.Any(p => p == r.Code))
            .ToList()
            .GetNode(parts, 0, null);
        Console.WriteLine("{0} {1} {2}", q.ID, q.ParentID, q.Code);
    }
