    public PageResult<Customer> Get(ODataQueryOptions<Customer> queryOptions)
    {
        IQueryable results = queryOptions.ApplyTo(_customers.AsQueryable());
        return new PageResult<Customer>(results as IEnumerable<Customer>, Request.GetNextPageLink(), Request.GetInlineCount());
    }
