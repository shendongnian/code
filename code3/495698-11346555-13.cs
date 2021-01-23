    public static class LinqReplacement
    {
        public delegate TResult Func<T, TResult>(T arg);
        public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);
        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            foreach (TSource item in source)
            {
                if (predicate(item) == true)
                    return item;
            }
            throw new InvalidOperationException("No item satisfied the predicate or the source collection was empty.");
        }
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            foreach (TSource item in source)
            {
                return item;
            }
            return default(TSource);
        }
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
        {
            foreach (object item in source)
            {
                yield return (TResult)item;
            }
        }
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");
            foreach (TSource item in source)
            {
                foreach (TResult subItem in selector(item))
                {
                    yield return subItem;
                }
            }
        }
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            var asCollection = source as ICollection;
            if(asCollection != null)
            {
                return asCollection.Count;
            }            
            int count = 0;
            foreach (TSource item in source)
            {
                count++;
            }
            return count;
        }
    }
