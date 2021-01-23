    public class ExtensionMethod
    {
        public static bool PenultimateCondition<T>(this IEnumerable<T> value)
        {
            T[] dt = value.ToArray();
            return Equals(dt[dt.Length-2], dt[dt.Length-1]);
        }
    }
