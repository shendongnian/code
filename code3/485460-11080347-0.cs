    XDocument document = XDocument.Parse(xml);
    var items = document.Root.Elements("item");
    foreach (var item in items)
    {
        var elements = item.Elements("item").OrderBy(a => a.Attribute("categoryid").Value).ToArray();
        item.Elements().Remove();
        item.Add(elements);
    }
    
    document.Save("your sorted xml path, which you want to save");
