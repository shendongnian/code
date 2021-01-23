    public static class CollectionExtensions
    {
        public static void AddRange<T>(ICollection<T> target, IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                target.Add(item);
            }	
        }
    }
