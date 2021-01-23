    public static IEnumerable<T> Zip<A, B, T>(
        this IEnumerable<A> seqA, IEnumerable<B> seqB, Func<A, B, T> func)
    {
        if (seqA == null) throw new ArgumentNullException("seqA");
        if (seqB == null) throw new ArgumentNullException("seqB");
     
        using (var iteratorA = seqA.GetEnumerator())
        using (var iteratorB = seqB.GetEnumerator())
        {
            while (iteratorA.MoveNext() && iteratorB.MoveNext())
            {
                yield return func(iteratorA.Current, iteratorB.Current);
            }
        }
    }
