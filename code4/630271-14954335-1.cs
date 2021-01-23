    static IEnumerable<string> Permuations(
        string input,
        char separator1, char separator2,
        string delimiter)
    {
        var enumerators = input.Split(separator1)
            .Select(s => s.Split(separator2).GetEnumerator()).ToArray();
        if (!enumerators.All(e => e.MoveNext())) yield break;
        while (true)
        {
            yield return String.Join(delimiter, enumerators.Select(e => e.Current));
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
