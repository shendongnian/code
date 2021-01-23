    public static int LongestSequence<T>(IEnumerable<T> source, IEqualityComparer<T> comparer)
    {
        comparer = comparer ?? EqualityComparer<T>.Default;
    
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext()) //empty sequence
                return 0;
            T previous = iterator.Current;
            int count = 1;
            int maxCount = 1;
    
            while (iterator.MoveNext())
            {
                if (comparer.Equals(iterator.Current, previous))
                {
                    count++;
                }
                else
                {
                    maxCount = Math.Max(maxCount, count);
                    count = 1;
                    previous = iterator.Current;
                }
            }
    
            return maxCount;
        }
    }
