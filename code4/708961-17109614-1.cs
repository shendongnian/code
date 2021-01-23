    var context = new AISDbContext();
    context.ApplyFilters(new List<IFilter<AISDbContext>>()
        {
            new AdminRoleFilter()
        });
    
    public List<Address> GetAddresses()
    {
        return context.Address.ToList();
    }
