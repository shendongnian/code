    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                target.Add(item);
            }	
        }
    }
