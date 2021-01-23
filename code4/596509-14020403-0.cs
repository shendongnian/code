    static IEnumerable<string> Tokenize(string str)
    {
        var sb = new StringBuilder();
        foreach (var c in str)
        {
            if(char.IsLetterOrDigit(c) || c == '_')
            {
                sb.Append(c);
            }
            else if (char.IsPunctuation(c))
            {
                if (sb.Length > 0) yield return sb.ToString();
                sb.Clear();
                yield return c.ToString(CultureInfo.InvariantCulture);
    
            }
        }
        if (sb.Length > 0) yield return sb.ToString();
    }
    static void Main(string[] args)
    {
        const string st = "(((EXAMPLE_WORD1 - EXAMPLE_WORD2)/EXAMPLE_WORD2) * 100)";
        Tokenize(st).ToList().ForEach(Console.WriteLine);
    }
