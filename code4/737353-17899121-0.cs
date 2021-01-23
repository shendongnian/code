    [Serializable]
    public class BookData
    {
      [XmlArray(ElementName="Books")]
      [XmlArrayItem(ElementName="Book")]
      public List<Book> Books {get; set;}
    
    }
