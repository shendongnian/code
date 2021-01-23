    public static IEnumerable BackwardsIterator(this List lst)
    {
        for(int i = lst.Count - 1; i >=0; i--)
        {
            yield return lst[i];
        }
    }
