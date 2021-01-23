    [Serializable]
    public class Root
    {
        [XmlElement("ITEMS")]
        public BOMItem[] Row { get; set; }
    }
    [Serializable]
    public class BOMItem
    {
        [XmlElement("ITEMNO")]
        public string ITEMNO { get; set; }
        [XmlElement("USED")]
        public string USED { get; set; }
        [XmlElement("PARTSOURCE")]
        public string PARTSOURCE { get; set; }
        [XmlElement("QTY")]
        public string QTY { get; set; }
    }
