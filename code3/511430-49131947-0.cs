        public static class StringExtensions
        {
            public static string ToBase64(this string text)
            {
                return ToBase64(text, Encoding.UTF8);
            }
            public static string ToBase64(this string text, Encoding encoding)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return text;
                }
                byte[] textAsBytes = encoding.GetBytes(text);
                return Convert.ToBase64String(textAsBytes);
            }
            public static bool TryParseBase64(this string text, out string decodedText)
            {
                return TryParseBase64(text, Encoding.UTF8, out decodedText);
            }
            public static bool TryParseBase64(this string text, Encoding encoding, out string decodedText)
            {
                if (string.IsNullOrEmpty(text))
                {
                    decodedText = text;
                    return false;
                }
                try
                {
                    byte[] textAsBytes = Convert.FromBase64String(text);
                    decodedText = encoding.GetString(textAsBytes);
                    return true;
                }
                catch (Exception)
                {
                    decodedText = null;
                    return false;
                }
            }
        }
