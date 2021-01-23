    [Serializable]
    public class Site
    {
        public string X { get; set; }
        [XmlIgnore]
        public XmlNamespaceManager xmlNS;
    }
