    public static void RemoveAll<T>(this EntityCollection<T> collection,
        Predicate<T> match) where T : EntityObject
    {
        collection.Where(entity => match(entity))
                  .ToList().ForEach(entity => collection.Remove(entity));
    }
