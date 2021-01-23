     public interface IRepository<T> : IDisposable
        {
            void Create(T entity);
    
            void Delete(T entity);
    
            void Update(T entity);
    
            IQueryable<T> GetAll();
    
            T GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        }
