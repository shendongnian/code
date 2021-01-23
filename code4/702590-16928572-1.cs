    public static IEnumerable<TResult> Zip<TA, TB, TResult>(
        this IEnumerable<TA> seqA, IEnumerable<TB> seqB, Func<TA, TB, TResult> func)
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
