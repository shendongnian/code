    public static IEnumerable<T> Shuffle<T>(this IList<T> lst)
    {
        Random rnd = new Random();
        for (int i = lst.Count - 1; i >= 0; i--)
        {
            int j = rnd.Next(i + 1);
            yield return lst[j];
            lst[j] = lst[i];
        }
    }
