    using (var context = new TestDBEntities())
    {
        var path = "foo/bar/baz";
        var q = context.TestTrees
            .ToList()
            .GetNode(path.Split('/'), 0, null);
        Console.WriteLine("{0} {1} {2}", q.ID, q.ParentID, q.Code);
    }
