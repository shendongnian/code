    static class StringExtensions
    {
        public static string Splice(this string str, int start, int length,
                                    string replacement)
        {
            return str.Substring(0, start) +
                   replacement +
                   str.Substring(start + length);
        }
    }
