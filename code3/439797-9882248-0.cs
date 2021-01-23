    public class Library
    {
        [XmlArray("Rows")]
        [XmlArrayItem("Row")]
        public List<Book> Books { get; set; }
    }
