    public static void RemoveAll<T>(this EntityCollection<T> collection,
        Predicate<T> match) where T : EntityObject
    {
        if (match == null) {
            throw new ArgumentNullException("match");
        }
        collection.Where(entity => match(entity))
                  .ToList().ForEach(entity => collection.Remove(entity));
    }
