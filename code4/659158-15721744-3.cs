    // DAL
    public class Entity { ... }
    // BL
    public class EntityInfo : Entity { ... }
    ...
    public IQueryable<EntityInfo> GetEntities()
    {
        return from e in dbContext.Entities
               select new EntityInfo
               {
                   // populate your application layer object
               }
    }
