    class Program {
        private static readonly Regex _classNameRegex = new Regex( @"\bfloat\b", RegexOptions.Compiled );
        
        private static IEnumerable<HtmlNode> GetFloatElements(HtmlDocument doc) {
            return doc
                .Descendants()
                .Where( n => n.NodeType == NodeType.Element )
                .Where( e => e.Name == "div" && _classNameRegex.IsMatch( e.GetAttributeValue("class", "") ) );
        }
    }
