    private static IEnumerable<HtmlNode> GetElementsWithClass(HtmlDocument doc, String className) {
            
        Regex regex = new Regex( "\\b" + Regex.Escape( className ) + "\\b", RegexOptions.Compiled );
            
        return doc
            .Descendants()
            .Where( n => n.NodeType == NodeType.Element )
            .Where( e => e.Name == "div" && regex.IsMatch( e.GetAttributeValue("class", "") ) );
    }
