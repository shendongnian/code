    public class RepositoryBase<TEntity> where TEntity : BaseEntity
    {
       public TEntity GetById(
         int id,
         params Expression<Func<TEntity, object>>[] includeList)
         {
                TEntity entity = null;
                ObjectQuery<TEntity> itemWithIncludes = context.Set<TEntity>() as ObjectQuery<TEntity>;
                foreach (Expression<Func<TEntity, object>> path in includeList)
                {
                    entityWithIncludes = ((IQueryable)itemWithIncludes.Include(path)) as ObjectQuery<T>;
                }
    
                IQueryable<TEntity> items = itemWithIncludes.AsQueryable<TEntity>();
                entity = items.Where(p => p.Id == id).SingleOrDefault();
                return entity;
         }
    }
