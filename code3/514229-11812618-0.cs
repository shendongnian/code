    namespace appUtils
    {
        public static class StringExtensions
        {
            public static bool In(this string s, params string[] values)
            {
                return values.Any(x => x.Equals(s));
            }
        }
    }
