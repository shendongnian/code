    public static class ListExt
    {
        public static List<T> Append<T>(this List<T> self, params T[] items)
        {
            if (items != null && self != null)
                self.AddRange(items);
            return self;
        }
    }
