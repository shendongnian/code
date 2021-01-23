    public static IEnumerable<IEnumerable<T>> Permutations<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        // Check source non-null, non-empty?
        var enumerables = source.ToArray();
        Stack<IEnumerator<T>> fe = new Stack<IEnumerator<T>>();
        fe.Push(enumerables[0].GetEnumerator());
        while (fe.Count > 0)
        {
            if (fe.Peek().MoveNext())
            {
                if (fe.Count == enumerables.Length)
                    yield return new Stack<T>(fe.Select(e => e.Current));
                else
                    fe.Push(enumerables[fe.Count].GetEnumerator());
            }
            else
            {
                fe.Pop().Dispose();
            }
        }
    }
