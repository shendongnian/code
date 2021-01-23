    protected IQueryable<EntityResult> GetEntities(ETBDataContext pContext)
    {
        IQueryable<Entity> query = pContext.Entities
           .Where(e => e.StatusCode == "Published");
        query = ApplyWhereClause(query);
        
        return from e in query
               orderby e.PublishDate descending
               select new EntityResult
                   {
                       Name = e.Name,
                       Link = e.Link
                   };
        }
    protected virtual IQueryable<Entity> ApplyWhereClause(IQueryable<Entity> entities)
    {
    }
  
