    public interface IUnitOfWork : System.IDisposable
    {
      IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
      void Save();
    }
    public interface IRepository<T> : IDisposable where T : class
    {
      void Add(T entity);
      void Delete(T entity);
      void Update(T entity);
      T GetById(long Id);
      IEnumerable<T> All();
      IEnumerable<T> AllReadOnly();
      IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    } 
