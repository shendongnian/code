    IEnumerable<XElement> GroupedElements(XElement root)
    {
        var groupedItems =
            from element in root.Elements()
            group element
            by new
            {
                Element = element.Name,
                Name = (string)element.Attribute("name"),
            };
        foreach (var g in groupedItems)
        {
            yield return new XElement("h3", g.Key.Name);
            var isMultiple = g.Skip(1).Any();
            if (isMultiple)
                yield return new XElement("ul",
                    from item in g
                    select new XElement("li", item.Value.Trim())
                );
            else
                yield return new XElement("p", g.Single().Value.Trim());
        }
    }
