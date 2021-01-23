    static class Extensions
    {
        public static string RemoveAll(this string src, string chars)
        {
            foreach(char c in chars)
                src= src.Replace(c.ToString(), "");
            return src;
        }
    }
