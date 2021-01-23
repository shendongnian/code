        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces { get; set; }
        [XmlAttribute("type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
