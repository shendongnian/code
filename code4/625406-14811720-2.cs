    public class GenericRepository<TEntity> : IRepository<TEntity> 
       where TEntity : class
    {
        private DbContext _context; // instead of ObjectContext
        private DbSet<TEntity> _set; // instead of IObjectSet<TEntity>
    
        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }
    
        public IQueryable<TEntity> GetQuery()
        {
            return _set;
        }
    
        public IEnumerable<TEntity> GetAll()
        {
            return GetQuery().AsEnumerable();
        }
    
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Where<TEntity>(predicate);
        }    
  
        // etc
    }
