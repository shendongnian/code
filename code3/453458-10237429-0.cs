    [XmlRoot("caravan", Namespace="urn:caravan")]
    public class Caravan
    {
        [XmlElement("vehicle")]
        public Auto Vehicle;
    
        //...
    }
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Truck))]
    [XmlRoot("auto", Namespace="")] // this makes it work
    public abstract class Auto
    {
        [XmlElement("make")] // not absolutely necessary but for consistency
        public string Make;
        [XmlElement("model")]
        public string Model;
    }
