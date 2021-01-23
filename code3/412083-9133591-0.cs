    string content = item.Element(nsContent + "encoded").Value;
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load(new StringReader(content));
    var text = doc.DocumentNode
                .Descendants("p")
                .Select(n => System.Web.HttpUtility.HtmlDecode(n.InnerText)).ToArray();
