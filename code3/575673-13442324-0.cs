    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var table = doc.DocumentNode.SelectNodes("//table/tr")
                   .Select(tr => tr.Elements("td").Select(td => td.InnerText).ToList())
                   .ToList();
