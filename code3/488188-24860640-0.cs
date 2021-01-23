    namespace System.Text
    {
        public static class StringBuilderExtensions
        {
            public static void AppendLineWithTwoWhiteSpacePrefix(this StringBuilder sb, string value)
            {
                sb.AppendFormat("{0}{1}{2}", "  ", value, Environment.NewLine);
            }
            public static void AppendLineWithTwoWhiteSpacePrefix(this StringBuilder sb)
            {
                sb.AppendFormat("{0}{1}", "  ", Environment.NewLine);
            }
        }
    }
