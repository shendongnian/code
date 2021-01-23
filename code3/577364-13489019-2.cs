    protected IQueryable<EntityResult> GetEntities(ETBDataContext pContext)
    {
        var q = pContext.Entities
            .Where(e => e.StatusCode == "Published")
            .Where(e => GetWhereCondition(e))
            .OrderByDescending(e => e.PublishDate)
            .Select(e => new EntityResult
               {
                   Name = e.Name,
                   Link = e.Link
               });
    }
    protected virtual Expression<Func<Entity, bool>> GetWhereCondition(Entity e)
    {
        return e => e.OtherColumn == "OtherValue";
    }
