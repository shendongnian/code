    public List<BufferFlatView> GetBufferFlatView(BufferFlatViewFilter filter)
    {
        //assumes IDbConnection instance injected by IOC
        var ev = dbConnection.CreateExpression<Campaign>();
    
        if (filter.TypeId.HasValue)
            ev.Where(x => x.TypeId == filter.TypeId.Value);
    
        if (filter.CustomerId.HasValue)
            ev.Where(x => x.CustomerId == filter.CustomerId);
    
        if (filter.Active)
            ev.Where(x => x.Active == filter.Active);
    
        return dbConnection.Select<Campaign>(ev);
}
