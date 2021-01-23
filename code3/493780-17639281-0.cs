    using HtmlAgilityPack;
    namespace MyExtensions {
        public static class HtmlNodeExtensions {
            public static HtmlNodeCollection SelectNodesSafe(this HtmlNode htmlNode, string xpath) {
                HtmlNodeCollection nodes = htmlNode.SelectNodes(xpath);
                if (nodes == null) {
                    return new HtmlNodeCollection(HtmlNode.CreateNode(""));
                }
                return nodes;
            }
        }
    }
