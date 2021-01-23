    public static IEnumerable<IEnumerable<T>> Permutations<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        var enumerables = source.ToArray();
        var fe = new Stack<IEnumerator<T>>();
        while (true)
        {
            while (fe.Count < enumerables.Length)
            {
                var toPush = enumerables[fe.Count].GetEnumerator();
                if (toPush.MoveNext())
                {
                    fe.Push(toPush);
                }
                else
                {
                    if (fe.Count > 0)
                    {
                        fe.Pop();
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
            yield return fe.Select(e => e.Current);
            while (!fe.Peek().MoveNext())
            {
                fe.Pop();
            }
            if (fe.Count == 0)
                yield break;
        }
    }
