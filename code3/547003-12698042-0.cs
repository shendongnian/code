    //http://htmlagilitypack.codeplex.com/
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var result = doc.DocumentNode.Descendants()
                    .Where(n => n is HtmlAgilityPack.HtmlTextNode)
                    .Select(n=>new {
                        IsDate = n.ParentNode.Name=="b" ? true: false,
                        Text = n.InnerText,
                    })
                    .ToList();
