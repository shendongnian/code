    public static class ListExtensions
    {
        /// <summary>
        /// Modifies the list by removing all items that match the predicate. Outputs the removed items.
        /// </summary>
        public static void RemoveWhere<T>(this List<T> input, Predicate<T> predicate, out List<T> removedItems)
        {
            removedItems = input.Where(item => predicate(item)).ToList();
            input.RemoveAll(predicate);
        }
        /// <summary>
        /// Modifies the list by removing all items that match the predicate. Calls the given action for each removed item.
        /// </summary>
        public static void RemoveWhere<T>(this List<T> input, Predicate<T> predicate, Action<T> actionOnRemovedItem)
        {
            RemoveWhere(input, predicate, out var removedItems);
            foreach (var removedItem in removedItems) actionOnRemovedItem(removedItem);
        }
    }
