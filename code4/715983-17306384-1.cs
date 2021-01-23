    public class MyContext: DbContext
    {
        public DbSet<Entity> Entities {get;set;}
    
        public IQueryable<Entity> NonDeletedEntities()
        {
            return this.Entities.Where(e => e.IsDeleted == false);
        }
    }
