    [XmlRoot("dc", Namespace= dc.NS_DC)]
    public class DCItem
    {
        [XmlElement("books")]
        public Books Books { get; set; }
    }
    public class Books
    {
        [XmlElement("title")]
        public Book[] Items { get; set; }
    }
    public class Book
    {
        [XmlText]
        public string Title { get; set; }
    }
