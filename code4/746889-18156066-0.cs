    public interface IEntity
            {
                int Id { get; set; } 
            } 
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
        {
            private IDbContext _context;
            public Repository(IDbContext context)
            {
                _context = context;
            }
              private IDbSet<TEntity> DbSet
             {
                get
                {
                    return _context.Set<TEntity>();
                }
             }
              public IQueryable<TEntity> GetAll() 
              {
                 return DbSet.AsQueryable(); 
              }
            public void Delete(TEntity entity)
            {
                 DbSet.Remove(entity);
            }
    .....
