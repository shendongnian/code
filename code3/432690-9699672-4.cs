    var doc = new HtmlDocument();
    doc.LoadHtml(html);
    foreach(var node in doc.DocumentNode.SelectNodes("//div|//span|//p"))
        if (string.IsNullOrWhiteSpace(node.InnerText.Replace(@"\n", string.Empty)))
            node.Remove();
    var result = doc.DocumentNode.OuterHtml;
