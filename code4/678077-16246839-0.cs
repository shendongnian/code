    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var tables = doc.DocumentNode.Descendants("table");
    int tablesCount = tables.Count();
    foreach (var table in tables)
    {
        var rows = table.Descendants("tr")
                        .Select(tr => tr.Descendants("td").Select(td => td.InnerText).ToList())
                        .ToList();
    }
