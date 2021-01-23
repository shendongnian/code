    public static class StringExtension
    {
        public static string Between(this string content, string start, string end)
        { 
            int startIndex = content.IndexOf(start) + start.Length;
            int endIndex = content.IndexOf(end) - (end.Length - 1);
            string result = content.Substring(startIndex, endIndex);
            return result;
        }
    }
