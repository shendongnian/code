    public static void AddItems<TSource>(this ICollection<TSource> orginalColl,
            IEnumerable<TSource> collectionToAdd)
    {
        foreach (var item in collectionToAdd)
        {
            orginalColl.Add(item);
        }
    }
