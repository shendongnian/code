    public static bool IsSorted(IEnumerable sequence)
    {
        // Now assuming that list
        using (IEnumerator iterator = sequence.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                // An empty sequence is always sorted
                return true;
            }
            IComparable previous = (IComparable) iterator.Current;
            while (iterator.MoveNext())
            {
                IComparable next = (IComparable) iterator.Current;
                if (next.CompareTo(previous) < 0)
                {
                    return false;
                }
                previous = next;
            }
            return true;
        }
    }
