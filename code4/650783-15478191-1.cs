    [XmlRoot(ElementName = "ROOT")]
    public class Root
    {
        public int id { get; set; }
        public int serial { get; set; }
        public string date { get; set; }
        [XmlArray(ElementName = "ITEMS")]
        [XmlArrayItem("ITEM")]
        public List<RootItem> Items { get; set; }
    }
    public class RootItem
    {
        public string name { get; set; }
        public string idd { get; set; }
        public string pd { get; set; }
        public string ed { get; set; }
    }
