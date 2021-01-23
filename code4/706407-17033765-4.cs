    public static class XmlHelper
    {
        public static XNode ReadFrom(Stream stream)
        {
            using (var xmlReader = XmlReader.Create(stream))
                return XDocument.Load(xmlReader);
        }
        public static void WriteTo(Stream stream, XNode node)
        {
            using (var xmlWriter = XmlWriter.Create(stream))
                node.WriteTo(xmlWriter);
        }
        public static XElement ToFirst(this XElement ancestor, String descendantLocalName)
        {
            return ancestor.Descendants().FirstOrDefault(element => element.Name.LocalName == descendantLocalName);
        }
        public static IEnumerable<XElement> ToAll(this XElement ancestor, String descendantLocalName)
        {
            return ancestor.Descendants().Where(element => element.Name.LocalName == descendantLocalName);
        }
        public static string ToAttribute(this XElement element, string name)
        {
            var attribute = element.Attribute(XName.Get(name));
            return attribute != null ? attribute.Value : null;
        }
    }
