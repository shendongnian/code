    [XmlRoot("books")]
    public class books
    {
        [XmlElement("bookNum")]
        public int bookNum { get; set; }
        [XmlRoot("book")]
        public class book
        {
            [XmlElement("name")]
            public string name { get; set; }
            [XmlRoot("record")]
            public class record
            {
                [XmlElement("borrowDate")]
                public string borrowDate { get; set; }
                [XmlElement("returnDate")]
                public string returnDate { get; set; }
            }
            
            [XmlArray("borrowRecords")]
            [XmlArrayItem("record")]
            public record[] records { get; set; }
        }
        [XmlArray("booksList")]
        [XmlArrayItem("book")]
        public book[] books { get; set; }
    }
