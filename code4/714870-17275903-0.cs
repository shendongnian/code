    public class DocumentOrder {
      // ...
      [XmlAttribute]
      public string Name { get; set; }
    
      [XmlArrayItem("Document")]
      public List<Document> Documents { get; set; }
    }
