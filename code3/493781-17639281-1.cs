    using HtmlAgilityPack;
    namespace MyExtensions {
        public static class HtmlNodeExtensions {
            /// <summary>
            ///     Selects a list of nodes matching the HtmlAgilityPack.HtmlNode.XPath expression.
            /// </summary>
            /// <param name="htmlNode">HtmlNode class to extend.</param>
            /// <param name="xpath">The XPath expression.</param>
            /// <returns>An <see cref="HtmlNodeCollection"/> containing a collection of nodes matching the <see cref="XPath"/> expression.</returns>
            public static HtmlNodeCollection SelectNodesSafe(this HtmlNode htmlNode, string xpath) {
                // Select nodes if they exist.
                HtmlNodeCollection nodes = htmlNode.SelectNodes(xpath);
                // I no matching nodes exist, return empty collection.
                if (nodes == null) {
                    return new HtmlNodeCollection(HtmlNode.CreateNode(""));
                }
                // Otherwise, return matched nodes.
                return nodes;
            }
        }
    }
