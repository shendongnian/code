    public static class Lists
    {
        public static List<T> Of<T>(T item0)
        {
            return new List<T> { item0 };
        }
        public static List<T> Of<T>(T item0, T item1)
        {
            return new List<T> { item0, item1 };
        }
        public static List<T> Of<T>(T item0, T item1, T item2)
        {
            return new List<T> { item0, item1, item2 };
        }
        ... as many times as you really care about, then ...
        public static List<T> Of<T>(params T[] items)
        {
            return items.ToList();
        }
    }
