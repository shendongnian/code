    public static class XDocumentExtensions
    {
        public static IEnumerable<XElement> ElementsCaseInsensitive(this XContainer source,  
            XName name)
        {
            return source.Elements()
                .Where(e => e.Name.Namespace == name.Namespace 
                    && e.Name.LocalName.Equals(name.LocalName, StringComparison.OrdinalIgnoreCase));
        }
    }
