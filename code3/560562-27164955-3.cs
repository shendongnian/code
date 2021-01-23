        public static string Replace(this string value, IEnumerable<Tuple<string, string>> pairs)
        {
            foreach (var pair in pairs) value = value.Replace(pair.Item1, pair.Item2);
            return value;
        }
        public static string EscapeStrings(this string value)
        {
            return value.Replace(new List<Tuple<string, string>> 
            { 
                new Tuple<string, string>(@"\", "\\\\"),
                new Tuple<string, string>(";",  @"\;"),
                new Tuple<string, string>(",",  @"\,"),
                new Tuple<string, string>("\r\n",  @"\n"),
            });
        }
