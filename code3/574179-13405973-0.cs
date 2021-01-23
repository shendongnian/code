    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var spans = doc.DocumentNode.SelectNodes("//span[@*]")
                    .Select(s => s.InnerText)
                    .ToList();
