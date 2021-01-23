    internal static string RemoveUnwantedTags(string data)
    {
        var document = new HtmlDocument();
        document.LoadHtml(data);
        var acceptableTags = new String[] { "strong", "em", "u"}
        var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
        while(nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            var parentNode = node.ParentNode;
                
            if(!acceptableTags.Contains(node.Name) && node.Name != "#text")
            {
                var childNodes = node.SelectNodes("./*|./text()");
                if (childNodes != null)
                {
                    foreach (var child in childNodes)
                    {
                        nodes.Enqueue(child);
                        parentNode.InsertBefore(child, node);
                    }
                }
                parentNode.RemoveChild(node);
            }
        }
        return document.DocumentNode.InnerHtml;
    }
