    public class DocumentOrder {
      // ...
      [XmlAttribute]
      public string Name { get; set; }
      [XmlElement("Document")]
      public List<Document> Documents { get; set; }
    }
