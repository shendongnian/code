     HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
     doc.LoadHtml(html);
     var table = doc.DocumentNode
                .Descendants("tr")
                .Select(n => n.Elements("td").Select(e => e.InnerText).ToArray());
