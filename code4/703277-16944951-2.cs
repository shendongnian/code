            public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                        params string[] includeProperties) {
                var query = dbSet.Where(e => !e.Deleted);
                // changed here
                query = includeProperties.Aggregate(query, (q, s) => q.Include(s));
                
                if (filter != null) {
                    query = query.Where(filter);
                }
                
                return orderBy != null ? orderBy(query).ToList() : query.ToList();
            }
