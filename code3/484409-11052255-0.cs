    public class Room
    {
         [XmlElement("light")]
         public Light Light { get; set; }
         [XmlElement("table")]
         public List<Table> Tables { get; set; }
    }
