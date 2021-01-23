    public static class Parse
    {
        public delegate bool ParseDelegate<T>(string s, out T result);
        public static T? FromString<T>(string value, ParseDelegate<T> parse) where T : struct
        {
            T result;
            var parsed = parse(value, out result);
            return parsed ? result : (T?)null;
        }
        public static int? ToNullableInt32(string value)
        {
            return FromString<int>(value, int.TryParse);
        }
        public static double? ToNullableDouble(string value)
        {
            return FromString<double>(value, double.TryParse);
        }
    }
