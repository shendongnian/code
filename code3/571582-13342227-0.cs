    public async Task<Store> FindClosestStore(DbGeography location)
    {
        using (var context = new StoreContext())
        {
            return await (from s in context.Stores
                orderby s.Location.Distance(location)
                select s).FirstAsync();
        }
    }
