    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Save(SaveOptions saveOptions);
    }
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IUnitOfWork Session { get; }
        IList<TEntity> GetAll();
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        bool IsValid(TEntity entity);
    }
