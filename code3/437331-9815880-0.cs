    public static IEnumerable<T> AlternateMerge<T>(this IEnumerable<T> source, 
                                                   IEnumerable<T> other)
    {
        using(var sourceEnumerator = source.GetEnumerator())
        using(var otherEnumerator = other.GetEnumerator())
        {
            bool haveItemsSource = true;
            bool haveItemsOther = true;
            while (haveItemsSource || haveItemsOther)
            {
                haveItemsSource = sourceEnumerator.MoveNext();
                haveItemsOther = otherEnumerator.MoveNext();
                if (haveItemsSource)
                    yield return sourceEnumerator.Current;
                if (haveItemsOther)
                    yield return otherEnumerator.Current;
            }
        }
    }
