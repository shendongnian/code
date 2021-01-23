    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeWithMaximum<T>(this IEnumerable<T> source, int maxCount)
        {
            if (source == null)
                throw new ArgumentNullException("source");
    
            int count = 0;
            foreach (T item in source)
            {
                if (++count > maxCount)
                    throw new InvalidOperationException(string.Format("More than the maximum specified number of elements ({0}) were returned.", maxCount));
    
                yield return item;
            }
        }
    }
