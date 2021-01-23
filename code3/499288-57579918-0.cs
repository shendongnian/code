    public static class LinqExtension
    {
        public static IEnumerable<IEnumerable<TSource>> Slice<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> selector,
            Func<TKey, TKey, bool> partition)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            if (partition == null) throw new ArgumentNullException(nameof(partition));
            var seed = new List<List<TSource>> { new List<TSource>() };
            return source.Aggregate(seed, (slices, current) => 
            {
                var slice = slices.Last();
                if (slice.Any())
                {
                    var previous = slice.Last();
                    if (partition(selector(previous), selector(current)))
                    {
                        slice = new List<TSource>();
                        slices.Add(slice);
                    }
                }
                slice.Add(current);
                return slices;
            }).Select(x => x.AsReadOnly());
        }
    }
