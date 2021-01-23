    static class Helper
    {
        public static void Push<T>(this List<T> list, T item)
        {
            if (list.Count == 5)
                list.RemoveAt(0);
            list.Add(item);
        }
    }
