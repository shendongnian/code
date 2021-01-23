    public class CustomXmlNodeReader : XmlNodeReader {
        private String _namespace;
        public CustomXmlNodeReader(XmlNode node) : base(node) {
            _namespace = node.NamespaceURI;
        }
        public override String NamespaceURI {
            get { return _namespace; }
        }
    }
