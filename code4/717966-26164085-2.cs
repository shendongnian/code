    public static class CollectionExtensions
    {
        public static void AddRange<T>(this IList<T> that, IEnumerable<T> collection)
        {
            if (that == null)
                throw new ArgumentNullException("that", "that is null.");
            if (collection == null)
                throw new ArgumentNullException("collection", "collection is null.");
            if (that is List<T>)
            {
                ((List<T>)that).AddRange(collection);
                return;
            }
            foreach (T item in collection)
                that.Add(item);
        }
        public static IEnumerable<IGrouping<TKey, TElem>> DoItForEachGroup<TKey, TElem>(this IEnumerable<IGrouping<TKey, TElem>> group, Action<IGrouping<TKey, TElem>> action)
        {
            if (group == null)
                throw new ArgumentNullException("group", "group is null.");
            if (action == null)
                throw new ArgumentNullException("action", "action is null.");
            group.ToList().ForEach(gr => action(gr));
            return group;
        }
    }
