    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var table = doc.DocumentNode.Descendants("tr")
               .Select(tr => tr.Descendants("td").Select(td => td.InnerText).ToList())
               .ToList();
