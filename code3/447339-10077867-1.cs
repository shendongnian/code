    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
            
    var nodes = doc.DocumentNode
        .Descendants("a")
        .Where(n => n.Attributes.Any(a => a.Name == "href" && a.Value.StartsWith("/abc/def")))
        .ToArray();
        
    foreach(var node in nodes)
    {
        node.ParentNode.RemoveChild(node,true);
    }
    var newHtml = doc.DocumentNode.InnerHtml;
