    public static IEnumerable<T> Merge<T>(IEnumerable<T> first, IEnumerable<T> second, IComparer<T> comparer = null)
    {
        comparer = comparer ?? Comparer<T>.Default;
    
        using (var firstIterator = first.GetEnumerator())
        using (var secondIterator = second.GetEnumerator())
        {
            if (!firstIterator.MoveNext())
            {
                while (secondIterator.MoveNext())
                    yield return secondIterator.Current;
                yield break;
            }
            else if (!secondIterator.MoveNext())
            {
                do
                {
                    yield return firstIterator.Current;
                } while (firstIterator.MoveNext());
                yield break;
            }
    
            T firstItem = firstIterator.Current;
            T secondItem = secondIterator.Current;
            while (true)
            {
                if (comparer.Compare(firstItem, secondItem) > 0)
                {
                    yield return secondItem;
                    if (secondIterator.MoveNext())
                    {
                        secondItem = secondIterator.Current;
                    }
                    else
                    {
                        do
                        {
                            yield return firstIterator.Current;
                        } while (firstIterator.MoveNext());
                        yield break;
                    }
                }
                else
                {
                    yield return firstItem;
                    if (firstIterator.MoveNext())
                    {
                        firstItem = firstIterator.Current;
                    }
                    else
                    {
                        do
                        {
                            yield return secondIterator.Current;
                        } while (secondIterator.MoveNext());
                        yield break;
                    }
                }
            }
        }
    }
