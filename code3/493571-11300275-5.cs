    [XmlRoot("Root")]
    public class RootElement{
        [XmlArray("EventSet")]
        [XmlArrayItem("Event")]
        public List<Event> events {get; set}
    }
