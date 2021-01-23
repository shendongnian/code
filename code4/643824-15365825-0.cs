    public static void ClearCache(this ISessionFactory sessionFactory)
    {
        sessionFactory.EvictQueries();
        foreach (var collectionMetadata in sessionFactory.GetAllCollectionMetadata())
                 sessionFactory.EvictCollection(collectionMetadata.Key);
        foreach (var classMetadata in sessionFactory.GetAllClassMetadata())
                 sessionFactory.EvictEntity(classMetadata.Key);
    }
