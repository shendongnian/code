    public static partial class Extensions
    {
        public static List<T> ToListOfSelf<T>(this T item)
        {
            return new List<T>() { item };
        }
    }
