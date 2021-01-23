    public static string StripXmlWhitespace(string Xml)
    {
        Regex Parser = new Regex(@">\s*<");
        Xml = Parser.Replace(Xml, "><");
    
        return Xml.Trim();
    }
