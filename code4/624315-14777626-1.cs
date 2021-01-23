    [Serializable]
    public class Library
    {
        [XmlElement]
        public string Location {get;set;}
        [XmlElement("Book")]
        public Book[] Book {get; set;}
    }
    public class Book 
    {
        /// ....
    }
