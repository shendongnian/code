    HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("option");
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var options = doc.DocumentNode.Descendants("option").Skip(1)
                    .Select(n => new
                    {
                        Value = n.Attributes["value"].Value,
                        Text = n.InnerText
                    })
                    .ToList();
