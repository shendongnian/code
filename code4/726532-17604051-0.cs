    public static void ConformDocument(XDocument doc)
    {
        var writeElements = doc.Descendants("a").ToList();
        if (writeElements.Count == 0)
            return;
        var root = doc.Descendants("pl");
        var ids = (from afs in root.Descendants("afs")
                    from af in afs.Descendants("af")
                    from attr in af.Attributes("id")
                    select attr.Value).Distinct(StringComparer.Ordinal).ToList();
        var elements = root
            .Descendants("pss")
            .Descendants("ps")
            .Descendants("a")
            .Select(a => new {element = a, aids = a.Descendants("x").Attributes("aid")});
        foreach (var e in elements)
        {
            foreach (var id in ids.Where(id => !e.aids.Any(attr => id.Equals(attr.Value))))
            {
                var element = new XElement("x");
                element.SetAttributeValue("aid", id);
                e.element.Add(element);
            }
        }
    }
