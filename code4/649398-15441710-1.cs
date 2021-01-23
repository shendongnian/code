    [XmlRoot("DIDL-Lite", Namespace = "urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/")]
    public class DIDLLite
    {
        [XmlElement("item")]
        public ContainerItem Item { get; set; }
    }
    public class ContainerItem
    {
        [XmlAttribute("id")]
        public string id { get; set; }
        [XmlAttribute("parentID")]
        public string parentID { get; set; }
        [XmlAttribute("restricted")]
        public string restricted { get; set; }
        [XmlAttribute("searchable")]
        public string searchable { get; set; }
        // you were missing these elements and their namespace
        [XmlElement(Namespace = "http://purl.org/dc/elements/1.1/")]
        public string creator { get; set; }
        [XmlElement(Namespace = "http://purl.org/dc/elements/1.1/")]
        public string date { get; set; }
        [XmlElement(Namespace = "http://purl.org/dc/elements/1.1/")]
        public string title { get; set; }
    }
