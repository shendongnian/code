    public static class ListExtensions
    {
        public static List<T> OrderByOrNull(this ICollection<T> collection, 
                                            Func<T,TKey> keySelector)
            if (collection!= null && collection.Count > 0) {
                return collection
                    .OrderBy(x => keySelector(x))
                    .ToList();
            }
            return null;
        }
    }
