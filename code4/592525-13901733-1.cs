    string html = @"<span class=""lnk"">Участники&nbsp;<span class=""clgry"">59728</span>";
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var list = doc.DocumentNode.SelectNodes("//span[@class='lnk']/span[@class='clgry']")
                  .Select(x => new
                  {
                      ParentText = x.ParentNode.FirstChild.InnerText,
                      Text = x.InnerText
                  })
                  .ToList();
