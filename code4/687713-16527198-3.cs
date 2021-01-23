    public MyXmlElement
    {
        public MyXmlElement()
        {
            // Add your own default namespace to your type to prevet xsi:* and xsd:*
            // attributes from being generated.
            this._namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
                new XmlQualifiedName(string.Empty, "urn:myDefaultNamespace") });
        }
        [XmlElement("MyNullableProperty", IsNullable=false)]
        public string MyNullableProperty
        {
            get
            {
                return string.IsNullOrWhiteSpace(this._myNullableProperty) ? 
                    null : this._myNullableProperty;
            }
            set { this._myNullableProperty = value; }
        }
        [XmlNamespacesDeclaration]
        public XmlSerializerNamespaces Namespaces { get { return this._namespaces; } }
        private XmlSerializerNamespaces _namespaces;
    }
