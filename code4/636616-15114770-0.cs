    public Tenant Find(int id)
    {
        // a few different options here -- assumes your key property is Id
        return context.UserProfile.OfType<Tenant>().SingleOrDefault(t => t.Id == id);
        // option 2 
        // even though your context does not expose a DbSet<Tenant>, you can still
        // use the Set<TResult>() method to get only tenants this way
        return context.Set<Tenant>().Find(id);
    }
    public void Add(Tenant tenant)
    {
        context.Add(tenant);
    }
    public void Remove(Tenant tenant)
    {
        context.Set<Tenant>().Remove(tenant);
    }
