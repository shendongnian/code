    static class HtmlNodeExtensions
    {
        public static List<HtmlNode> GetChildNodesDiscardingTextOnes(this HtmlNode node)
        {
            return node.ChildNodes.Where(n => n.NodeType != HtmlNodeType.Text).ToList();
        }
    }
