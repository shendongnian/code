    public static class Extensions
    {
        public static int FindFirstIndexGreaterThanOrEqualTo<TElement, TKey>(
                    this IList<TElement> sortedCollection, TKey key, Func<TElement, TKey> keySelector, IComparer<TKey> comparer)
        {
            int begin = 0;
            int end = sortedCollection.Count;
            while (end > begin)
            {
                int index = (begin + end) / 2;
                TElement el = sortedCollection[index];
                TKey currElKey = keySelector(el);
                if (comparer.Compare(currElKey, key) >= 0)
                    end = index;
                else
                    begin = index + 1;
            }
            return end;
        }
        public static int BinarySearch<TElement, TKey>(this IList<TElement> sortedCollection, TKey key, Func<TElement, TKey> keySelector)
        {
            var comparer = Comparer<TKey>.Default;
            int index = sortedCollection.FindFirstIndexGreaterThanOrEqualTo(key, keySelector, comparer);
            if (index >= sortedCollection.Count)
                return -1;
            if (index >= 0 && comparer.Compare(keySelector(sortedCollection[index]), key) != 0)
                return -1;
            return index;
        }
    }
