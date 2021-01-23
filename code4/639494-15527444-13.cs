    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext, new()
    {
      private readonly IDbContext _ctx;
      private Dictionary<Type, object> _repositories;
      private bool _disposed;
    
      public UnitOfWork()
      {
        _ctx            = new TContext();
        _repositories   = new Dictionary<Type, object>();
        _disposed       = false;
      }
     
      public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
      {
        if (_repositories.Keys.Contains(typeof(TEntity)))
          return _repositories[typeof(TEntity)] as IRepository<TEntity>;
     
        var repository = new Repository<TEntity>(_ctx);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
      }
     
      public void Save()
      {
         try
         {
           _ctx.SaveChanges();
         }
         catch (DbUpdateConcurrencyException ex)
         {
           ex.Entries.First().Reload();
         }
      }
     
      …
    }
        
    public class Repository<T> : IRepository<T> where T : class
    {
      private readonly IDbContext _context;
      private readonly IDbSet<T> _dbset;
    
      public Repository(IDbContext context)
      {
        _context = context;
        _dbset   = context.Set<T>();
      }
    
      public virtual void Add(T entity)
      {
        _dbset.Add(entity);
      }
    
      public virtual void Delete(T entity)
      {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Deleted;
      }
    
      public virtual void Update(T entity)
      {
        var entry = _context.Entry(entity);
        _dbset.Attach(entity);
        entry.State = EntityState.Modified;
      }
     
      public virtual T GetById(long id)
      {
        return _dbset.Find(id);
      }
     
      public virtual IEnumerable<T> All()
      {
        return _dbset.ToList();
      }
     
      public virtual IEnumerable<T> AllReadOnly()
      {
        return _dbset.AsNoTracking().ToList();
      }
     
      public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
      {
        return _dbset.Where(predicate);
      }
    
    }
