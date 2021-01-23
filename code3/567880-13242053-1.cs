    public static void DelayedRemove<T>(this IEnumerable<T item> collection, T itemToRemove) {
        // add it to a private static dictionary bound to the `collection` instance.
    }
    public static void DelayedRemoveFinish(this IEnumerable<T item> collection) {
        // empty the private static dictionary in here
    }
