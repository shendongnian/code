    public static class CollectionExtensions
    {
        public static List<TSource> OrderByAsListOrNull<TSource, TKey>(
            this ICollection<TSource> collection, Func<TSource,TKey> keySelector)
            if (collection != null && collection.Count > 0) {
                return collection
                    .OrderBy(x => keySelector(x))
                    .ToList();
            }
            return null;
        }
    }
