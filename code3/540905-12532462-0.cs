    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(markup);
    var dups = doc.DocumentNode.Descendants()
        .Where(n => n.Attributes["id"] != null)
        .GroupBy(n => n.Attributes["id"].Value)
        .Select(g => new { ID = g.Key, Count = g.Count() })
        .Where(r=>r.Count>1)
        .ToList();
