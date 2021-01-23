    public static IEnumerable<T> IterateWhileMutating<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            yield return list[i];
        }
    }
