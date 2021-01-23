    public class BaseContent
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
    
    [XmlType(TypeName = "EventObject")]
    public class Event : BaseContent
    {
        [XmlAttribute("EventId")]
        public int EventId { get; set; }
    }
    
    [XmlType(TypeName = "NewsObject")]
    public class News : BaseContent
    {
        [XmlAttribute("NewsId")]
        public int NewsId { get; set; }
    }
