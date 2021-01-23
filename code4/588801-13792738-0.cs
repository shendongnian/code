    XmlSerializer ser = new XmlSerializer(typeof(console[]),new XmlRootAttribute("consoles"));
    var consoles = (console[])ser.Deserialize(stream);
    public class console
    {
        [XmlAttribute]
        public string name;
        public int year;
        public string manufacturer;
    }
