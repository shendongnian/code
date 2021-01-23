    public static IEnumerable<IEnumerable<T>> Permutations<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        var epairs = source
            .Select(i => new { enumerable = i, enumerator = i.GetEnumerator() })
            .ToArray();
        bool incremented = true;
        foreach (var e in epairs)
        {
            if (!e.enumerator.MoveNext())
            {
                incremented = false; // this will skip to the end
                break;
            }
        }
        while (incremented)
        {
            // Return current state.
            yield return epairs.Select(ep => ep.enumerator.Current).ToArray();
            incremented = false;
            for (int i = epairs.Length - 1; i >= 0 && !incremented; i--)
            {
                if (epairs[i].enumerator.MoveNext())
                    incremented = true;
                else
                {
                    epairs[i].enumerator.Dispose();
                    epairs[i] = new
                    {
                        enumerable = epairs[i].enumerable,
                        enumerator = epairs[i].enumerable.GetEnumerator()
                    };
                    epairs[i].enumerator.MoveNext();
                }
            }
        }
        // All of our iterators are finished.
        foreach (var e in epairs)
            e.enumerator.Dispose();
    }
