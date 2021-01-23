    public static class RegexMatchExtensions
    {
        public static int LastIndexOf(this MatchCollection matches, int index)
        {
            var match = matches.Cast<Match>().LastOrDefault(m => m.Index <= index);
            return (match == null)? -1 : match.Index;
        }
    
        public static int IndexOf(this MatchCollection matches, int index)
        {
            var match = matches.Cast<Match>().FirstOrDefault(m => m.Index > index);
            return (match == null)? -1 : match.Index;
        }
    }
