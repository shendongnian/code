    public class XmlFilteringReader : XmlReader
    {
        private readonly XmlReader _source;
        private bool _gotXmlDeclaration = false;
        private bool _gotDoctype = false;
        public XmlFilteringReader(XmlReader source)
        {
            _source = source;
        }
        public override bool Read()
        {
            var ok = _source.Read();
            if (ok && _source.NodeType == XmlNodeType.ProcessingInstruction
                    && _source.LocalName == "xml")
            {
                if (_gotXmlDeclaration) return Read(); // Recursive
                _gotXmlDeclaration = true;
            }
            else if (ok && _source.NodeType == XmlNodeType.DocumentType)
            {
                if (_gotDoctype) return Read(); // Recursive
                _gotDoctype = true;
            }
            return ok;
        }
        // Implementation of other methods and properties
        // by calling the same method or property on _source
    }
