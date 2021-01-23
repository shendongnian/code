    var cdoc = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement("root")); 
    cdoc.Root.Add(
        results.Select(x=>
        {
            var element = new XElement("maincat", new XAttribute("id", x.Id));
            element.Add(new XElement("name", x.Name));
            element.Add(x.Subcategories.Select(c=>
            {
                var subcat = new XElement("subcat", new XAttribute("id", c.Id));
                subcat.Add(new XElement("name", c.Name));
                return subcat;
            }).ToArray());
            return element;
        }));
