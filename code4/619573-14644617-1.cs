    static class Extension
    {
        public static String EscapeCsvField(this String source, Char delimiter, Char escapeChar)
        {
            if (source.Contains(delimiter) || source.Contains(escapeChar))
                return String.Format("{0}{1}{0}", escapeChar, source);
            return source;
        }
    }
