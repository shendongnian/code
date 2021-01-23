    public static class MyExtensions
    {
        public static ICollection<T> AddChainable<T>(this ICollection<T> collection, T newItem)
        {
            collection.Add(newItem);
            return collection;
        }
    }
