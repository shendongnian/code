    public static class StringBuilderExtensions
    {
        public static bool EndsWith(this StringBuilder sb, string text)
        {
            if (sb.Length < text.Length)
                return false;
            var sbLength = sb.Length;
            var textLength = text.Length;
            for (int i = 1; i <= text.Length; i++)
            {
                if (text[textLength - i] != sb[sbLength - i])
                    return false;
            }
            return true;
        }
    }
