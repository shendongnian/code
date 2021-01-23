    using System.Linq;
    private static IEnumerable<HtmlNode> GetElementsWithClass(HtmlDocument doc, String[] classNames) {
        
        Regex[] exprs = new Regex[ classNames.Length ];
        for( Int32 i = 0; i < exprs.Length; i++ ) {
            exprs[i] = new Regex( "\\b" + Regex.Escape( classNames[i] ) + "\\b", RegexOptions.Compiled );
        }
        return doc
            .Descendants()
            .Where( n => n.NodeType == NodeType.Element )
            .Where( e =>
                e.Name == "div" &&
                exprs.All( r =>
                    r.IsMatch( e.GetAttributeValue("class", "") )
                )
            );
    }
