    public static string xml = "<foo><subfoo><subsubfoo>content</subsubfoo></subfoo><subfoo/></foo>";
    public static Regex re = new Regex(@"\<([A-Za-z0-9]*)\b[^>]*\>(.*?)\</\1\>");
    
    static string GetContentViaRegex()
    {
        string content = xml;
        while (re.IsMatch(content))
        {
            Match match = re.Match(content);
            if (!match.Success)
                break;
    
            content = match.Groups[2].Value;
        }
        return content;
    }
