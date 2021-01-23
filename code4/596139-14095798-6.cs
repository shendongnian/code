    public class BaseContent
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
    
    public class Event : BaseContent
    {
        [XmlAttribute("EventId")]
        public int EventId { get; set; }
        public Event() { }
    }
    
    public class News : BaseContent
    {
        [XmlAttribute("NewsId")]
        public int NewsId { get; set; }
        public News() { }
    }
