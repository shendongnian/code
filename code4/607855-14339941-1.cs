    static class StringExt
    {
        public static string ReverseStr(this string str)
        {
            return new string(str.ToCharArray().Reverse().ToArray());
        }
    }
