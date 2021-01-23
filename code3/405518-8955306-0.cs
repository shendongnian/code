    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext) {
            _dbContext = dbContext;
            
            _dbSet = _dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> Entities {
            get { return _dbSet; }
        }
        public TEntity FindOne(int id) {
            return Entities.FirstOrDefault(t => t.Id == id);
        }
    }
