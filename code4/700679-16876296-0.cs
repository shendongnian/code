    var stream = File.Open(filename, FileMode.Open);
    XmlSerializer ser = new XmlSerializer(typeof(RestaurantFoodImpls));
    var result = ser.Deserialize(stream) as RestaurantFoodImpls;
----
    public class FoodItem
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string ID { get; set; }
    }
    public class Restaurant
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string PhoneNumber { get; set; }
        [XmlAttribute]
        public string MobileNumber { get; set; }
        [XmlAttribute]
        public string LastName { get; set; }
        [XmlAttribute]
        public string ID { get; set; }
        [XmlAttribute]
        public string FirstName { get; set; }
    }
    public class RestaurantFood
    {
        [XmlAttribute]
        public string Price { get; set; }
        [XmlAttribute]
        public string ID { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
        [XmlElement("foodItem")]
        public FoodItem foodItem { get; set; }
        [XmlElement("restaurant")]
        public Restaurant restaurant { get; set; }
    }
    [XmlRoot("restaurantFoodImpls")]
    public class RestaurantFoodImpls
    {
        [XmlElement("RestaurantFood")]
        public List<RestaurantFood> RestaurantFood { get; set; }
    }
