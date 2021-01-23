    public static TSource MinBy<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, IComparable> projectionToComparable
    ) {
        using (var e = source.GetEnumerator()) {
            if (!e.MoveNext()) {
                throw new InvalidOperationException("Sequence is empty.");
            }
            TSource min = e.Current;
            IComparable minProjection = projectionToComparable(e.Current);
            while (e.MoveNext()) {
                IComparable currentProjection = projectionToComparable(e.Current);
                if (currentProjection.CompareTo(minProjection) < 0) {
                    min = e.Current;
                    minProjection = currentProjection;
                }
            }
            return min;                
        }
    }
