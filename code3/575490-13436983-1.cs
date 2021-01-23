    public static void RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate)     {
    var i = collection.Count;
    while(--i > 0) {
        var element = collection.ElementAt(i);
        if (predicate(element)) {
            collection.Remove(element);
        }
    }
