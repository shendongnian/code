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
            if (ancestor == null)
                return null;
            return ancestor.Descendants().FirstOrDefault(element => element.Name.LocalName == descendantLocalName);
        }
        public static IEnumerable<XElement> ToAll(this XElement ancestor, String descendantLocalName)
        {
            if (ancestor == null)
                return null;
            return ancestor.Descendants().Where(element => element.Name.LocalName == descendantLocalName);
        }
        public static string ToAttribute(this XElement element, string name)
        {
            return element.Attribute(XName.Get(name)).MaybePipe(x => x.Value);
        }
    }
