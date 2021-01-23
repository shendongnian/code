    using (IEnumerator<TSource> enumerator1 = first.GetEnumerator())
    using (IEnumerator<TSource> enumerator2 = second.GetEnumerator())
    {
        while (enumerator1.MoveNext())
        {
            if (!enumerator2.MoveNext() || !comparer.Equals(enumerator1.Current, enumerator2.Current))
            {
                return false;
            }
        }
        if (enumerator2.MoveNext())
        {
            return false;
        }
    }
    
    return true;
