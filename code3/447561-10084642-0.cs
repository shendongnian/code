    string html = "<meta itemprop=\"rating\" content=\"4.7\">";
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var content = doc.DocumentNode
                    .Element("meta")
                    .Attributes
                    .Where(a => a.Name == "content")
                    .First()
                    .Value;
