    public static class Extensions
    {
        public static IObservable<IList<TSource>> BufferUntil<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate)
        {
            var published = source.Publish().RefCount();
            return published.Buffer(() => published.Where(predicate));
        }
        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
        {
            return source.Reverse().Take(count).Reverse();
        }
    }
