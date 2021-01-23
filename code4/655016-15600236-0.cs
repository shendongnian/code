    public static class Extensions
    {
        public static int CountOf(this string data, Char c)
        {
            return string.IsNullOrEmpty(data) ? 0 : data.Count(chk => chk == c);
        }
    }
