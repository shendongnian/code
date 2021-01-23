    private readonly static Dictionary<char, Type> Tokens = new Dictionary<char, Type> { 
            { '\n', typeof(Break) },
            { '\t', typeof(TabChar) }
        };
    
    private static IEnumerable<OpenXmlElement> Tokenize(string text)
    {
        var start = 0;
        var pos = 0;
    
        foreach (var c in text)
        {
            Type tokenType;
            if (Tokens.TryGetValue(c, out tokenType))
            {
                if (pos > 0)
                {
                    yield return new Text(text.Substring(start, pos));
                }
                yield return (OpenXmlElement)Activator.CreateInstance(tokenType);
                start += pos + 1;
                pos = 0;
            }
            else
            {
                pos++;
            }
        }
    
        if (pos > 0)
        {
            yield return new Text(text.Substring(start));
        }
    }
    
    static void Main(string[] args)
    {
        var tokens = Tokenize("This is a test string.\n \t This is a new line with a tab").ToArray();
    
    }
