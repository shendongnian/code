    public static class ListUtilities
    {
        public static List<T> New<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
