    var doc = new HtmlAgilityPack.HtmlDocument();
    HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
    doc.LoadHtml(html);
    var values = doc.DocumentNode.SelectNodes("//select[@name='selectname']/option")
                    .Where(o => o.InnerText=="text")
                    .Select(o => o.Attributes["value"].Value)
                    .ToList();
