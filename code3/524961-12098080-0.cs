    private enum WORD_FORMAT
    {
        NUMBER = 0,
        ARRAY = 1,
        ASSOC = 2
    };
    private static object str_word_count(string str, WORD_FORMAT format, string charlist)
    {
        string wordchars = string.Format("{0}{1}", "a-z", Regex.Escape(charlist));
    
        var words = Regex.Matches(str, string.Format("[{0}]+(?:[{0}'\\-]+[{0}])?", wordchars), RegexOptions.Compiled | RegexOptions.IgnoreCase);
    
        if (format == WORD_FORMAT.ASSOC)
        {
            var assoc = new Dictionary<int, string>(words.Count);
            foreach (Match m in words)
                assoc.Add(m.Index, m.Value);
            return assoc;
        }
        else if (format == WORD_FORMAT.ARRAY)
        {
            return words.Cast<Match>().Select(m => m.Value).ToArray();
        }
        else // default to number.
        {
            return words.Count;
        }
    }
