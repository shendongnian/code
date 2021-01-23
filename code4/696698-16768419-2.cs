    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            // implementation ...
        }
        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where = null)
        {
            // implementation
        }
        public void Update(TEntity entity)
        {
            // update your entity ...
        }
        // etc...
    }
