    public class Location
    {
          [XmlAttribute("name");
          public string Name;
          public List<Building> Buildings;
    }
    public class Building
    {
         [XmlAttribute("name");
         public string Name;
         public List<Room> Rooms;
    }
