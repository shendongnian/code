    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(somehtmlstring);
    string value = doc.DocumentNode.Descendants("a")
        .First(n => n.Attributes["class"].Value == "someclass")
        .Attributes["href"]
        .Value;
