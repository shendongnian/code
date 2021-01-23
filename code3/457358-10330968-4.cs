    public class ExtensionMethod
    {
        public static bool PenultimateCondition(this IEnumerable<DateTime> value)
        {
            Datetime[] dt = value.ToArray();
            return dt[dt.Length-2] == dt[dt.Length-1];
        }
    }
