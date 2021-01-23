    internal static string RemoveUnwantedTags(string data)
    {
        var document = new HtmlDocument();
        document.LoadHtml(data);
        var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
        while(nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            var parentNode = node.ParentNode;
                
            if(node.Name != "strong" && node.Name != "em" && node.Name != "u" && node.Name != "#text")
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
