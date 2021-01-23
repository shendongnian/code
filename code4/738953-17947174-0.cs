    [Serializable]
    public class BulkDataExchangeRequests : XmlNs
    {
        [XmlElement("Header")]
        public Header Header { get; set; }
        [XmlElement("AddFixedPriceItemRequest")]
        public List<AddFixedPriceItemRequest> ListAddFixedPriceItemRequest { get; set; }
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new System.Xml.XmlQualifiedName[] { new System.Xml.XmlQualifiedName("", XmlnsAttribute) });
    }
    [Serializable]
    public class AddFixedPriceItemRequest : XmlNs
    {
        [XmlElement("ErrorLanguage")]
        public string ErrorLanguage { get; set; }
        [XmlElement("WarningLevel")]
        public string WarningLevel { get; set; }
        [XmlElement("Version")]
        public string Version { get; set; }
        [XmlElement("Item")]
        public ItemType Item { get; set; }
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new System.Xml.XmlQualifiedName[] { new System.Xml.XmlQualifiedName("", XmlnsAttribute) });
    }
