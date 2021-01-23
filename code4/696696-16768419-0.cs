    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? Context.Set<TEntity>().Where(where) : Context.Set<TEntity>();
        }
        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where = null)
        {
            return FindAll(where).FirstOrDefault();
        }
        public void Update(TEntity entity)
        {
            // update your entity ...
        }
        // etc...
    }
