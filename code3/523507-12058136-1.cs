    using (var wc = new WebClient())
    {
        var page = wc.DownloadString(url);
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(page);
        //XPath
        var title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
        var text = doc.DocumentNode.SelectSingleNode("//div[@id='readInner']")
                      .InnerText;
        //Linq
        var text = doc.DocumentNode.Descendants("div")
                    .Where(n => n.Attributes["id"].Value == "readInner")
                    .First()
                    .InnerText;
    }
