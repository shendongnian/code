    [XmlType("title")]
    public class Title 
    {
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot("dc")]
    public class DCItem 
    {
        [XmlArray("books")]
        public List<Title> Books { get; set; }
    }
