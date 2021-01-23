        static readonly string invalidXmlChars =
            Enumerable.Range(0, 0x20)
            .Where(i => !(i == '\u000A' || i == '\u000D' || i == '\u0009'))
            .Select(i => (char)i)
            .ConcatToString()
            + "\uFFFE\uFFFF";
        public static string RemoveInvalidXmlChars(string str)
        {
            return RemoveInvalidXmlChars(str, false);
        }
        internal static string RemoveInvalidXmlChars(string str, bool forceRemoveSurrogates)
        {
            if (str == null) throw new ArgumentNullException("str");
            if (!ContainsInvalidXmlChars(str, forceRemoveSurrogates))
                return str;
            str = str.RemoveCharset(invalidXmlChars);
            if (forceRemoveSurrogates)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (IsSurrogate(str[i]))
                    {
                        str = str.Where(c => !IsSurrogate(c)).ConcatToString();
                        break;
                    }
                }
            }
            return str;
        }
        static bool IsSurrogate(char c)
        {
            return c >= 0xD800 && c < 0xE000;
        }
        internal static bool ContainsInvalidXmlChars(string str)
        {
            return ContainsInvalidXmlChars(str, false);
        }
        public static bool ContainsInvalidXmlChars(string str, bool forceRemoveSurrogates)
        {
            if (str == null) throw new ArgumentNullException("str");
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 0x20 && !(str[i] == '\u000A' || str[i] == '\u000D' || str[i] == '\u0009'))
                    return true;
                if (str[i] >= 0xD800)
                {
                    if (forceRemoveSurrogates && str[i] < 0xE000)
                        return true;
                    if ((str[i] == '\uFFFE' || str[i] == '\uFFFF'))
                        return true;
                }
            }
            return false;
        }
