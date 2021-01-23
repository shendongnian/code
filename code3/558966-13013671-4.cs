    ...
        public static string Escape(this string str)
        {
            return "\"" + str.Replace("\"","\"\"") + "\"";
        }
