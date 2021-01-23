            public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                        params string[] includeProperties) {
                DbQuery<TEntity> query = dbSet.Where(e => !e.Deleted);
                if (filter != null) {
                    query = query.Where(filter);
                }
                // changed here
                query = includeProperties.Aggregate(query, (q, s) => q.Include(s));
                return orderBy != null ? orderBy(query).ToList() : query.ToList();
            }
