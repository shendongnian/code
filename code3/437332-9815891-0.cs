    static IEnumerable<T> Interleave(this IEnumerable<T> a, IEnumerable<T> b)
    {
        bool bEmpty = false;
        using (var enumeratorB b.GetEnumerator())
        {
            foreach (var elementA in a)
            {
                yield return elementA;
                if (!bEmpty && bEnumerator.MoveNext())
                    yield return bEnumerator.Current;
                else
                    bEmpty = true;
            }
            if (!bEmpty)
                while (bEnumerator.MoveNext())
                    yield return bEnumerator.Current;
        }
    }
