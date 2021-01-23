    public interface IRepository<T>
    {
        IEnumerable<T> List();
        IEnumerable<T> List(Func<T, bool> pred);
    
        T Get(int id);
        T Get(Func<T, bool> pred);
    
        void Add(T entity);
    
        T Update(T entity);
    
        void Delete(T entity);
        void Delete(Func<T, bool> pred);
    }
    
    public abstract class AbstractRepository<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity
    {
        protected TContext context;
    
        public AbstractRepository(UnitOfWork<TContext> unit)
        {
            context = unit.Context;
        }
    
        public virtual IEnumerable<TEntity> List()
        {
            return context.Set<TEntity>();
        }
    
        public virtual IEnumerable<TEntity> List(Func<TEntity, bool> pred)
        {
            return context.Set<TEntity>().Where(pred);
        }
    
        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
    
        public virtual TEntity Get(Func<TEntity, bool> pred)
        {
            return context.Set<TEntity>().FirstOrDefault(pred);
        }
    
        public virtual void Add(TEntity entity)
        {
            if (entity.Id <= 0)
                context.Entry(entity).State = System.Data.EntityState.Added;
        }
    
        public virtual TEntity Update(TEntity entity)
        {
            if (entity.Id > 0)
            {
                context.Entry(entity).State = System.Data.EntityState.Modified;
                return entity;
            }
            return null;
        }
    
        public virtual void Delete(TEntity entity)
        {
            context.Entry(entity).State = System.Data.EntityState.Deleted;
        }
    
        public virtual void Delete(Func<TEntity, bool> pred)
        {
            foreach (var entity in List(pred))
            {
                Delete(entity);
            }
        }
    }
