    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
            
    var node = doc.DocumentNode
        .Descendants("a")
        .Where(n => n.Attributes.Any(a => a.Name == "href" && a.Value.StartsWith("/abc/def")))
        .First();
    node.ParentNode.RemoveChild(node,true);
    var newHtml = doc.DocumentNode.InnerHtml;
