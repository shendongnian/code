    [XmlRoot("hotels")]
    public class HotelData
    {
        [XmlAttribute("num")]
        public string Id { get; set; }
    
        [XmlElement("hotel")]
        public List<Hotel> Hotels { get; set; }
    }
    
    public class Hotel
    {
        [XmlAttribute("num")]
        public string Id { get; set; }
    
        [XmlAttribute("item")]
        public string Item { get; set; }
    }
