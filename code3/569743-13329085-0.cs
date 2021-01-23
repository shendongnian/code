    public static IQueryable<T> Search<T>(this IQueryable<T> source, List<Expression<Func<T, bool>>> predicates = null)
                where T : EntityObject
            {
                if (predicates == null || predicates.Count == 0)
                    return source;
                else if (predicates.Count == 1)
                    return source.Where(predicates[0]);
                else
                {
                    var query = PredicateBuilder.False<T>();
                    foreach (var predicate in predicates)
                    {
                        query = query.Or(predicate);
                    }
    
                    return source.AsExpandable().Where(query);
                }
            }
