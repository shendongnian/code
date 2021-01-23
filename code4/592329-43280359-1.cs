        public class InvalidEncodingException : System.Exception
        { }
        public static IEnumerable<string> UnicodeCodepoints(this string s)
        {
            for (int i = 0; i < s.Length; ++i)
            {
                if (Char.IsSurrogate(s[i]))
                {
                    if (s.Length < i + 2)
                    {
                        throw new InvalidEncodingException();
                    }
                    yield return string.Format("{0}{1}", s[i], s[++i]);
                }
                else
                {
                    yield return string.Format("{0}", s[i]);
                }
            }
        }
    }
