    string html = @"<span class=""lnk"">Участники&nbsp;<span class=""clgry"">59728</span>";
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var population = doc.DocumentNode.SelectSingleNode("//span[@class='clgry']")
                        .InnerText;
