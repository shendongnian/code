    HtmlDocument doc = new HtmlDocument();
    doc.Load("test.html");
    var spanNode = doc.DocumentNode.Descendants("span")
                        .Where(x => x.Attributes["class"]!=null && x.Attributes["class"].Value == "cvetica")
                        .FirstOrDefault();
    if (spanNode != null)
    {
        string text = spanNode.InnerText;
    }
