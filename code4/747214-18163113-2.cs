    public static class PageableExtension
    {
        public static IPageableQuery<T> AsPageable<T>(this IQueryable<T> sourceQuery, int pageSize)
        {
            return new PageableQuery<T>(sourceQuery, pageSize);
        }
        public static IOrderedPageableQuery<T> OrderBy<T, U>(this IPageableQuery<T> sourcePageableQuery, Expression<Func<T, U>> orderBy)
        {
            return new OrderedPageableQuery<T>(sourcePageableQuery, Queryable.OrderBy(sourcePageableQuery, orderBy));
        }
        public static IOrderedPageableQuery<T> OrderByDescending<T, U>(this IPageableQuery<T> sourcePageableQuery, Expression<Func<T, U>> orderBy)
        {
            return new OrderedPageableQuery<T>(sourcePageableQuery, Queryable.OrderByDescending(sourcePageableQuery, orderBy));
        }
        public static IOrderedPageableQuery<T> ThenBy<T, U>(this IOrderedPageableQuery<T> sourcePageableQuery, Expression<Func<T, U>> orderBy)
        {
            return new OrderedPageableQuery<T>(sourcePageableQuery, Queryable.ThenBy(sourcePageableQuery, orderBy));
        }
        public static IOrderedPageableQuery<T> ThenByDescending<T, U>(this IOrderedPageableQuery<T> sourcePageableQuery, Expression<Func<T, U>> orderBy)
        {
            return new OrderedPageableQuery<T>(sourcePageableQuery, Queryable.ThenByDescending(sourcePageableQuery, orderBy));
        }
        public static IQueryable<T> Page<T>(this IPageableQuery<T> sourceQuery, int pageNumber)
        {
            return sourceQuery.Skip((pageNumber - 1) * sourceQuery.PageSize)
                              .Take(sourceQuery.PageSize);
        }
    }
