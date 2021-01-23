    internal static class EnumerableExtensions
    {
        public static int IndexOfNth<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, int skip = 0)
        {
            var index = 0;
            foreach (var value in enumerable)
            {
                if (predicate(value))
                {
                    if (skip-- == 0)
                        return index;
                }
                index++;
            }
            return -1;
        }
    
        public static int IndexOfFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable.IndexOfNth(predicate);
        }
    }
