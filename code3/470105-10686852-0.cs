    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(xml);
                       
    doc.DocumentNode
        .Descendants("strong")
        .ToList().ForEach(n => n.ParentNode.ParentNode.RemoveChild(n.ParentNode, true));
    var newXml = doc.DocumentNode.InnerHtml;
