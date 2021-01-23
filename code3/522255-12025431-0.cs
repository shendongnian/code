    internal class Utils
    {
        private static Regex _regexCategory = new Regex(
            @"(?<name>c(ategory){0,1}):(?<value>([^""\s]+)|("".+""))\s*", 
            RegexOptions.IgnoreCase);
        private static Regex[] _allRegexes = { _regexCategory };
    
    
        public static string ExtractKeyWords(string queryString)
        {
            if (string.IsNullOrWhiteSpace(queryString))
                return null;
    
            //change it to your needs, I just made it compile
            return _allRegexes[0].Match(queryString).Value;
        }
    }    
    
    class Program
    {
        static void Main(string[] args)
        {
            string result = Utils.ExtractKeyWords("foo");
        }
    }
