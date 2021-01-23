        public TEntity Item(Expression<Func<TEntity, bool>> wherePredicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                _dbSet.Include(property);
            }
            return _dbSet.Where(wherePredicate).FirstOrDefault();
        }
