    public class Location
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        public List<Building> Buildings { get; set; }
    }
    
    public class Building
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
    
    public class Room
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
    
    [XmlRoot("info")]
    public class Info
    {
        [XmlArray("locations")]
        [XmlArrayItem("location")]
        public List<Location> Locations { get; set; }
    }
