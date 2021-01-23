    public static IEnumerable<IEnumerable<T>> LockStepSequences<T>(this IEnumerable<IEnumerable<T>> sequences)
    {
        var iters = sequences
            .Select((s, index) => new { active=true, index, enumerator = s.GetEnumerator() })
            .ToArray();
 
        var isActive = iters.Select(it => it.enumerator.MoveNext()).ToArray();
        var numactive = isActive.Count(flag => flag);
 
        try
        {
            while (numactive > 0)
            {
                T min = iters
                    .Where(it => isActive[it.index])
                    .Min(it => it.enumerator.Current);
 
                var row = new T[iters.Count()];
 
                for (int j = 0; j < isActive.Length; j++)
                {
                    if (!isActive[j] || !Equals(iters[j].enumerator.Current, min)) 
                        continue;
 
                    row[j] = min;
                    if (!iters[j].enumerator.MoveNext())
                    {
                        isActive[j] = false;
                        numactive -= 1;
                    }
                }
                yield return row;
            }
        }
        finally
        {
            foreach (var iter in iters) iter.enumerator.Dispose();
        }
    }
