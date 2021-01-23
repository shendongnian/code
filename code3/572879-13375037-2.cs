    private static string Pattern(string src)
    {
        return ".*" + String.Join(".*", src.ToCharArray());
    }
    private static bool RMatch(string src, string dest)
    {
        try
        {
            return Regex.Match(dest, Pattern(src), RegexOptions.IgnoreCase).Success;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    private static List<string> RSearch(
    string word,
    IEnumerable<string> wordList,
    double fuzzyness)
    {
        // Tests have prove that the !LINQ-variant is about 3 times
        // faster!
        List<string> foundWords =
            (
                from s in wordList
                where RMatch(word, s) == true
                orderby s.Length ascending 
                select s
            ).ToList();
        return foundWords;
    }
