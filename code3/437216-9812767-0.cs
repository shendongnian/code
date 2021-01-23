    [XmlRoot("Cars"), XmlType("Cars")]
    public class SomeWrapper {
        [XmlElement("Car")]
        public List<Car> Cars { get { return cars; } }
        private readonly List<Car> cars = new List<Car>();
    }
