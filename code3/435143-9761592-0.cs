    [XmlRoot("FoodPhoneNumbers")]
    public class FoodPhoneNumbers
    {
        [XmlElement(ElementName = "Restaurant")]
        public List<Restaurant> Restaurants { get; set; }
    }
    public class Restaurant
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement]
        public string Type { get; set; }
        [XmlElement]
        public string PhoneNumber { get; set; }
        [XmlElement(ElementName = "Hours")]
        public List<Hours> Hours { get; set; }
    }
    public class Hours
    {
        [XmlElement]
        public string Open { get; set; }
        [XmlElement]
        public string Close { get; set; }
    }
