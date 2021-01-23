            public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                        params string[] includeProperties) {
                
                var query = ((DbQuery<TEntity>)dbset);
                query = includeProperties.Aggregate(query, (q, s) => q.Include(s));
                
                query = query.Where(e => !e.IsDeleted);
                
                
                if (filter != null) {
                    query = query.Where(filter);
                }                
                return orderBy != null ? orderBy(query).ToList() : query.ToList();
            }
