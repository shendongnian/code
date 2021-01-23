    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(str);
    foreach (var li in doc.DocumentNode.Descendants("li"))
    {
        if (li.ParentNode.Name == "ul") li.Name = "Unordered";
        if (li.ParentNode.Name == "ol") li.Name = "Ordered";
    }
    var output = new StringWriter();
    doc.Save(output);
