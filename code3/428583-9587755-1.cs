    class Program
    {
        static Dictionary<string, string> replacements = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            replacements.Add("\\Break", Environment.NewLine);
            string template = @"This is an \\Break escaped newline and this should \Break contain a newline.";
            // (?<=($|[^\\])(\\\\){0,}) will handle double escaped items
            string outcome = Regex.Replace(template, @"(?<=($|[^\\])(\\\\){0,})\\\w+\b", ReplaceMethod);
        }
        public static string ReplaceMethod(Match m)
        {
            string replacement = null;
            if (replacements.TryGetValue(m.Value, out replacement))
            {
                return replacement;
            }
            else
            {
                //return string.Empty?
                //throw new FormatException()?
                return m.Value;
            }
        }
    }
