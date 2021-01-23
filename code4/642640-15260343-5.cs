    private static Office LoadFurthest(PPContext context)
    {
        Office i4 = context.Offices
                .Where(o => o.id == 1)
                .First();
        var t1 = (
            from c in i4.Clients
            from p in c.Policies
            from i in p.Images
            select i )
            .ToList();
            
        return i4;
    }
