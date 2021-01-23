    // Note: to use this, you'd need to make sure that *both* sequences are sorted.
    // You could either sort TwoThousandIntegerList in place, or use LINQ's OrderBy
    // method.
    public IEnumerable<T> SortedIntersect<T>(this IEnumerable<T> first,
        IEnumerable<T> second) where T : IComparable<T>
    {
        using (var firstIterator = first.GetEnumerator())
        {
            if (!firstIterator.MoveNext())
            {
                yield break;
            }
            using (var secondIterator = second.GetEnumerator())
            {
                if (!secondIterator.MoveNext())
                {
                    yield break;
                }
                T firstValue = firstIterator.Current;
                T secondValue = secondIterator.Current;
                while (true)
                {
                    int comparison = firstValue.CompareTo(secondValue);
                    if (comparison == 0) // firstValue == secondValue
                    {
                        yield return firstValue;
                    }
                    else if (comparison < 0) // firstValue < secondValue
                    {
                        if (!firstIterator.MoveNext())
                        {
                            yield break;
                        }
                        firstValue = firstIterator.Current;
                    }
                    else // firstValue > secondValue
                    {
                        if (!secondIterator.MoveNext())
                        {
                            yield break;
                        }
                        secondValue = secondIterator.Current;
                    }  
                }                
            }
        }
    }
