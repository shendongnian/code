    public static class StringExtensions
    {
        static StringExtensions()
        {
            var whiteSpaceList = new List<char>();
            for (int i = char.MinValue; i <= char.MaxValue; i++)
            {
                char c = Convert.ToChar(i);
                if (char.IsWhiteSpace(c))
                {
                    whiteSpaceList.Add(c);
                }
            }
            WhiteSpaces = whiteSpaceList.ToArray();
        }
        public static readonly char[] WhiteSpaces;
        public static string[] SplitWhiteSpacesAndMore(this string str, IEnumerable<char> otherDeleimiters, StringSplitOptions options = StringSplitOptions.None)
        {
            var separatorList = new List<char>(WhiteSpaces);
            separatorList.AddRange(otherDeleimiters);
            return str.Split(separatorList.ToArray(), options);
        }
    }
