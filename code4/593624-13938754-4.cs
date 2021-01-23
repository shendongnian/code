    public static IEnumerable<T> WhereOrFirstOfRest<T>(
        this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        // Materialize the complete collection.
        collection = collection.ToArray();
        // Filter the collection. ToArray prevents calling the predicate
        // twice for any item.
        var filtered = collection.Where(predicate).ToArray();
        return filtered.Any() ? filtered : collection.Take(1);
    }
