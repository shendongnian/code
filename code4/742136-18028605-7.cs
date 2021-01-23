    public static void RemoveAll<T>(this IList<T> iList, IEnumerable<T> itemsToRemove, IEqualityComparer<T> comparer = null)
    {
        var set = new HashSet<T>(itemsToRemove, comparer ?? EqualityComparer<T>.Default);
        if (iList is List<T> list)
        {
            list.RemoveAll(set.Contains);
        }
        else
        {
            int i = iList.Count - 1;
            while (i > -1)
            {
                if (set.Contains(iList[i])) iList.RemoveAt(i);
                else i--;
            }
        }
    }
