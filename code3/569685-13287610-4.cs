    public static IEnumerable<IEnumerable<T>> Permutations<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        // Check source non-null, non-empty?
        var enumerables = source.ToArray();
        Stack<IEnumerator<T>> fe = new Stack<IEnumerator<T>>();
        fe.Push(enumerables[0].GetEnumerator());
        while (true)
        {
            if (fe.Peek().MoveNext())
            {
                if (fe.Count == enumerables.Length)
                    yield return fe.Select(e => e.Current).Reverse().ToArray();
                else
                    fe.Push(enumerables[fe.Count].GetEnumerator());
            }
            else
            {
                if (fe.Count == 1)
                {
                    yield break;
                }
                else
                {
                    fe.Pop().Dispose();
                }
            }
        }
    }
