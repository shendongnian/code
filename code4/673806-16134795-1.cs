    using (XmlReader reader = XmlReader.Create(new StringReader(this.XML)))
    {
        XElement xml = XElement.Load(reader);
        var all = xml.Elements("Category").Flatten(x => x.Elements("Category"));
        var leafs = from cat in all
                    where cat.Elements("Category").Any() == false
                    select cat;
        // or go through all...
        var categories =
            from cat in all
            select new
            {
                Name = cat.Attribute("Name"),
                ID = cat.Attribute("ID"),
                IsLeaf = cat.Elements("Category").Any() == false,
                SubCount = cat.Elements("Category").Count(),
                // Subs = cat.Elements("Category").Select(x => x.Attribute("Name").ToString()).ToArray(),
            };
        // or put into dictionary etc.
        var hash = categories.ToDictionary(x => x.Name);
    }
