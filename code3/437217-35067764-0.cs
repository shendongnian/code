    [XmlRoot("Cars")]
    public class ListCars
    {
        [XmlElement("Car")]
        public List<Car> Car { get; set; }
    }
