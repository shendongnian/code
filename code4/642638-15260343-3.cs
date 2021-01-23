    private static Office LoadList(PPContext context)
    {
        Office i2 = context
            .Offices
            .Where(o => o.id == 1)
                .First();
        i2.Clients
            .ToList()
            .ForEach(a => a
                .Policies
                .ToList()
                .ForEach(b => b
                    .Images
                    .ToList()));
        return i2;
    }
