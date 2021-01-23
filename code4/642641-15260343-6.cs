    using (DBContext context = new DBContext()
    {
        parentNode = context.
            .Tree
            .Include(inc => inc.Children)
            .Where(query => query.IsSomeWayToIDTheParentNode)
            .ToArray();
    }
