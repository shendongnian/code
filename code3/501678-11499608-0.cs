    public static void AddItems<TSource>(this IList<TSource> orginalColl,
        IEnumerable<TSource> collectionToAdd)
    {
        foreach (var item in collectionToAdd)
        {
            orginalColl.Add(item);             
        }             
    }
