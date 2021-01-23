    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var list = Recurse(doc.DocumentNode);
---
    List<Person> Recurse(HtmlAgilityPack.HtmlNode root)
    {
        var ol = root.Element("ol");
        if (ol == null) return null;
        return ol.Elements("li")
                    .Select(li => new Person
                    {
                        Name = li.FirstChild.InnerText.Trim(),
                        Children = Recurse(li)
                    })
                    .ToList();
    }
