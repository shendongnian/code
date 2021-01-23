    public static class CollectionExtensions
    {
        public static void AddItem<T>(this List<T> list, T item)
        {
           if (!list.Contains(item))
           {
              list.Add(item);
           }
        }
    }
