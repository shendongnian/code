    public static pListExtensions
    {
        public static pList<T> ToPList<T>(this IEnumerable<T> items)
        {
            return new pList<T>(items);
        }
    }
