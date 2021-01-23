    public static IEnumerable<T> Intersect<T>(IEnumerable<IEnumerable<T>> sequences)
    {
        using (var iterator = sequences.GetEnumerator())
        {
            if (!iterator.MoveNext())
                return Enumerable.Empty<T>();
            HashSet<T> intersection = new HashSet<T>(iterator.Current);
            while (iterator.MoveNext())
                intersection.IntersectWith(iterator.Current);
            return intersection;
        }
    }
