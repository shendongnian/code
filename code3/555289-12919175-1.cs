    var xDoc = XDocument.Load(.....);
    var loc = xDoc.Root.Descendants2("predefinedLocation").First();
    var id = loc.Attribute("id");
    var value = loc.Descendants2("value").First().Value;
    public static class S_O_Extensions
    {
        public static IEnumerable<XElement> Descendants2(this XElement xRoot, string name)
        {
            return xRoot.Descendants().Where(n => n.Name.LocalName == name);
        }
    }
