    [XmlType("Access")]
    public class Access
    {
       public Access(){}
    
       [XmlArray("Phone")]
       [XmlArrayItem("Item")]
       public AccessItem[] Computer;
    
       [XmlArray("Computer")]
       [XmlArrayItem("Item")]
       public AccessItem[] Phone;
    }
    
    public class AccessItem
    {
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
