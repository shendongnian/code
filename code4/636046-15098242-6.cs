    public static int BinarySearch<TSource, TKey>(this IList<TSource> collection
        , TKey item, Func<TSource, TKey> selector, Comparer<TKey> comparer = null)
    {
        return BinarySearch(collection, item, selector, comparer, 0, collection.Count);
    }
    private static int BinarySearch<TSource, TKey>(this IList<TSource> collection
        , TKey item, Func<TSource, TKey> selector, Comparer<TKey> comparer
        , int startIndex, int endIndex)
    {
        comparer = comparer ?? Comparer<TKey>.Default;
        while (true)
        {
            if (startIndex == endIndex)
            {
                return startIndex;
            }
            int testIndex = startIndex + ((endIndex - startIndex) / 2);
            int comparision = comparer.Compare(selector(collection[testIndex]), item);
            if (comparision > 0)
            {
                endIndex = testIndex;
            }
            else if (comparision == 0)
            {
                return testIndex;
            }
            else
            {
                startIndex = testIndex + 1;
            }
        }
    }
