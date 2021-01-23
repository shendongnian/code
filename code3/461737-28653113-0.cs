    public virtual void DeleteWhere(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "")
            {
                IQueryable<TEntity> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
    
                foreach (var entity in query)
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }
            }
