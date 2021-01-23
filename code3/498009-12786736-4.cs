    public class MyRepository<TContext> : IRepository<EntityType> where TContext: DbContext, new()
    {
        private TContext context;
        
        public MyRepository(TContext context)
        {
            this.context = context;
        }
        
        public IQueryable<T> Fetch()
        {
           return context.EntityTypes;
        }
        
        // Insert and update logic
    }
