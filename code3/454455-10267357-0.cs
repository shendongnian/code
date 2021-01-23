    public static class HtmlNodeExtensions
    {
        public static IEnumerable<HtmlNode> GetElementsByTagName(this HtmlNode parent, string name)
        {
            return parent.Descendants().Where(node => node.Name == name);
        }
    }
