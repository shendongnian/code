    public static IEnumerable<T> RemoveSequentialRepeats<T>(
          this IEnumerable<T> source)
    {
        using (var iterator = source.GetEnumerator())
        {
            var comparer = EqualityComparer<T>.Default;
            if (!iterator.MoveNext())
                yield break;
            var current = iterator.Current;
            yield return current;
            while (iterator.MoveNext())
            {
                if (comparer.Equals(iterator.Current, current))
                    continue;
                current = iterator.Current;
                yield return current;
            }
        }        
    }
