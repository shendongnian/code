    var xDoc = XDocument.Load(.....);
    var loc = GetNodes(xDoc.Root, "predefinedLocation").First();
    var id = loc.Attribute("id");
    var val = GetNodes(loc,"value").First().Value;
    IEnumerable<XElement> GetNodes(XElement xRoot, string name)
    {
        return xRoot.Descendants().Where(n => n.Name.LocalName == name);
    }
