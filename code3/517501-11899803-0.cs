        static readonly Dictionary<char, string> replacements =
           new Dictionary<char, string>
        {
            {']',"Ć"}, {'~', "č"} // etc
        };
        static readonly Regex replaceRegex;
        static YourUtilityType() // static initializer
        {
            StringBuilder pattern = new StringBuilder().Append('[');
            foreach(var key in replacements.Keys)
                pattern.Append(Regex.Escape(key.ToString()));
            pattern.Append(']');
            replaceRegex = new Regex(pattern.ToString(), RegexOptions.Compiled);
        }
        public static string Sanitize(string input)
        {
            return replaceRegex.Replace(input, match =>
            {
                return replacements[match.Value[0]];
            });
        }
