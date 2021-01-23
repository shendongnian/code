    public static int CountIntersect<T>(this IEnumerable<T> collectionA, IEnumerable<T> collectionB)
    {
        HashSet<T> tempA = new HashSet<T>(collectionA);
        int Result = 0;
        foreach (var itemB in collectionB)
        {
            if (tempA.Remove(itemB))
                Result++;
        }
        return Result;
    }
