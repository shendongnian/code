    public static class NumericExtensions
    {
        public static bool IsBetween(this int value, int fromInclusive, int toInclusive)
        {
            return value >= fromInclusive && value <= toInclusive;
        }
        public static Decimal? TryGetDecimal(this string item)
        {
            Decimal d;
            bool success = Decimal.TryParse(item, out d);
            return success ? (Decimal?)d : (Decimal?)null;
        }
        public static int? TryGetInt(this string item)
        {
            int i;
            bool success = int.TryParse(item, out i);
            return success ? (int?)i : (int?)null;
        }
        public static bool TryGetBool(this string item)
        {
            bool b = false;
            Boolean.TryParse(item, out b);
            return b; ;
        }
        public static Version TryGetVersion(this string item)
        {
            Version v;
            bool success = Version.TryParse(item, out v);
            return v;
        }
    }
