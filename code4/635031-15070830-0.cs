    static IEnumerable<string> Permutations(
        IEnumerable<string> input,
        char separator)
    {
        var enumerators = input
           .Select(s => s.Split(separator).GetEnumerator())
            .ToArray();
        if (!enumerators.All(e => e.MoveNext())) yield break;
        while (true)
        {
            yield return String.Join(separator, enumerators.Select(e => e.Current));
            if (enumerators.Reverse().All(e => {
                    bool finished = !e.MoveNext();
                    if (finished)
                    {
                        e.Reset();
                        e.MoveNext();
                    }
                    return finished;
                }))
                yield break;
        }
    }
