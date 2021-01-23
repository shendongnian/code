    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var list = doc.DocumentNode.Descendants("ul")
        .Select(n => n.Descendants("li").Select(li => new {id=li.Id,text=li.InnerText }).ToList())
        .ToList();
    foreach (var ul in list)
    {
        foreach(var li in ul)
        {
            Console.WriteLine(li.id + " " +  li.text);
        }
        Console.WriteLine();
    }
