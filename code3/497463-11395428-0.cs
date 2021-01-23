    public class rootname
    {
        public rootname() { }
    
        [XmlElement("AListItem")]
        public List<AListItem> DataList { get; set; } // <<< public!
    
        public string Name { get; set; }
    }
