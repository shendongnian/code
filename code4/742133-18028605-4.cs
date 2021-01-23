    public static void RemoveAll<T>(this IList<T> iList, IEnumerable<T> itemsToRemove, IEqualityComparer<T> comparer)
    {
        var set = new HashSet<T>(itemsToRemove, comparer);
        var list = iList as List<T>;
        if (list == null)
        {
            int i = 0;
            while (i < iList.Count)
            {
                if (set.Contains(iList[i])) iList.RemoveAt(i);
                else i++;
            }
        }
        else
        {
            list.RemoveAll(set.Contains);
        }
    }
