    protected IQueryable<EntityResult> GetEntities(ETBDataContext pContext)
    {
        var q = pContext.Entities
            .Where(e => e.StatusCode == "Published");
        q = q.AddWhereCondition(q)
            .OrderByDescending(e => e.PublishDate)
            .Select(e => new EntityResult
               {
                   Name = e.Name,
                   Link = e.Link
               });
    }
    protected virtual IQueryable<Entity> AddWhereCondition(IQueryable<Entity> query)
    {
        return query.Where(e => e.OtherColumn == "OtherValue");
    }
