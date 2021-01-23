    [Serializable()]
    [XmlRoot("Cars")]
    public class Cars
    {
        [XmlElement("Car",typeof(Car))]
        public Car[] Car { get; set; }
    }
    
    [Serializable()]
    public class Car
    {
        [XmlElement("Id")]
        public long Id { get; set; }
    
        [XmlElement("BMW",typeof(BMW))]
        public BMW[] BMW { get; set; }
    }
