    public class Data
    {
        public ItemTransferIn ItemIn { get; set; }
    }
    public class ItemTransferIn
    {
        [XmlAttribute("date")]
        public DateTime Date { get; set; }
    
        [XmlAttribute("itemId")]
        public string Itemid { get; set; }
    
        [XmlAttribute]
        public int Id { get; set; }
    
        public Extensions Extensions { get; set; }
    }
    public class Extensions
    {
        public ExtensionsInfo Info { get; set; }
    }
    public class ExtensionsInfo
    {
        public int Id { get; set; }
        [XmlAttribute("order")]
        public string Order { get; set; }
    }
