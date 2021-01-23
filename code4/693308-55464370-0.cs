    public static class OrderBuilder
    {
        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> queryable, params Tuple<Expression<Func<TSource, object>>, bool>[] keySelectors)
        {
            if (keySelectors == null || keySelectors.Length == 0) return queryable;
    
            return keySelectors.Aggregate(queryable, (current, keySelector) => keySelector.Item2 ? current.OrderDescending(keySelector.Item1) : current.Order(keySelector.Item1));
        }
    
        private static bool IsOrdered<TSource>(this IQueryable<TSource> queryable)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
    
            return queryable.Expression.Type == typeof(IOrderedQueryable<TSource>);
        }
    
        private static IQueryable<TSource> Order<TSource, TKey>(this IQueryable<TSource> queryable, Expression<Func<TSource, TKey>> keySelector)
        {
            if (!queryable.IsOrdered()) return queryable.OrderBy(keySelector);
    
            var orderedQuery = queryable as IOrderedQueryable<TSource>;
    
            return (orderedQuery ?? throw new InvalidOperationException()).ThenBy(keySelector);
        }
    
        private static IQueryable<TSource> OrderDescending<TSource, TKey>(this IQueryable<TSource> queryable, Expression<Func<TSource, TKey>> keySelector)
        {
            if (!queryable.IsOrdered()) return queryable.OrderByDescending(keySelector);
    
            var orderedQuery = queryable as IOrderedQueryable<TSource>;
            return (orderedQuery ?? throw new InvalidOperationException()).ThenByDescending(keySelector);
        }
    }
