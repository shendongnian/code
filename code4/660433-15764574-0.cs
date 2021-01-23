    public PageResult<dynamic> Get(string entityName)
    {
        var query = EntityHelper.GetQueryable(entityName).Select("new (Id, SysName)");
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.AddEntity(query.ElementType);
        var model = modelBuilder.GetEdmModel();
        var options = new ODataQueryOptions(new ODataQueryContext(model, query.ElementType), this.Request);
        IQueryable results = options.ApplyTo(query);
    
        return new PageResult<dynamic>(results as IEnumerable<dynamic>, Request.GetNextPageLink(), Request.GetInlineCount());
    }
