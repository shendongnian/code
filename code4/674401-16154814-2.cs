    public interface IRepository<TEntity>
    {
        void Save(TEntity entity);
        TEntity Get(Guid id);
    }
