    string content = item.Element(nsContent + "encoded").Value;
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load(new StringReader(content));
    var text = String.Join(Environment.NewLine + Environment.NewLine,
                    doc.DocumentNode
                    .Descendants("p")
                    .Select(n => "\t" + System.Web.HttpUtility.HtmlDecode(n.InnerText))
                );
