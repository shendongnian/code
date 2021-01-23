    using (var context = new UnicornsContext())
    {
        // Query for all unicorns without tracking them
        var unicorns1 = context.Unicorns.AsNoTracking();
        // Query for some unitcorns without tracking them
        var unicorns2 = context.Unicorns
            .Where(u => u.Name.EndsWith("ky"))
            .AsNoTracking()
            .ToList();
    } 
