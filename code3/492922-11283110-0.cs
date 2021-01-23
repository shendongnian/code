    [XmlRoot("result")]
    public class VehicleDetails
    {
        public string Type { get; set; }
        public string Make { get; set; }
        public Country Country { get; set; }
    }
    
    public class Country
    {
        [XmlText]
        public string Name { get; set; }
    }
