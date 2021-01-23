        public delegate bool ParseDelegate<T>(string s, out T result);
        public static T? ParseOrNull<T>(this string str, ParseDelegate<T> Parse)
            where T: struct
        {
            T result;
            if (!Parse(str, out result))
                return null;
            return result;
        }
        public static T ParseOrNull<T>(this string str, ParseDelegate<T> Parse)
            where T : class
        {
            T result;
            if (!Parse(str, out result))
                return null;
            return result;
        }
