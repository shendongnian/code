    public static class CollectionExtensions
    {
        public static List<T> OrderByAsListOrNull<T,TKey>(this ICollection<T> collection, 
                                                  Func<T,TKey> keySelector)
            if (collection != null && collection.Count > 0) {
                return collection
                    .OrderBy(x => keySelector(x))
                    .ToList();
            }
            return null;
        }
    }
