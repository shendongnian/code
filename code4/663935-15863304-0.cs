    public class PunctionationSignsSpaceing
    {
        private string _pattern;
        public PunctionationSignsSpaceing()
        {
            _pattern = " *([),!;?.]) *";
        }
        public string FormatString(string str)
        {
            str = Regex.Replace(
                str, _pattern, "$1 ",
                RegexOptions.Multiline | RegexOptions.Compiled
            );
            return str;
        }
    }
