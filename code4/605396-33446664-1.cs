     public static class QueryableExtensions
    {
        public static IEnumerable<TItem> Select<TSource, TItem>(this IQueryable<TSource> source)
            where TSource : NameIdPair
            where TItem : SelectListItem, new()
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Select(CreateLambda<TSource, TItem>());
        }
        public static Expression<Func<TSource, TItem>> CreateLambda<TSource, TItem>()
            where TSource : NameIdPair
            where TItem : SelectListItem, new()
        {
            return (t) => new TItem { Name = t.Name, Value = t.Id };
        }
    }
