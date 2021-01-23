    [XmlRoot(ElementName = "ROOT")]
    public class Root
    {
        public string ATTR1 { get; set; }
        public string ATTR2 { get; set; }
        public string ATTR3 { get; set; }
        [XmlArray(ElementName = "ITEMS")]
        [XmlArrayItem("ITEM")]
        public List<RootItem> Items { get; set; }
    }
	[XmlRoot(ElementName = "ROOTITEM")]
    public class RootItem
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
    }
