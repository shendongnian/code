    public static class StringExt
    {
        public static List<string> AsList(this string self)
        {
            return new List<string> { self };
        }
    }
