    public IQueryable<EntityInfo> GetEntities()
    {
        return from e in dbContext.Entities
               select new EntityInfo
               {
                   // populate your application layer object
               }
    }
