    var items = new List<XElement>();
    foreach (var item in configFiles)
    {
        items.AddRange(XDocument.Parse(item)
                                .Root.Elements("Item")
                                .OrderBy(x => (string) x.Attribute("ID")));
    }
    Items = items;
