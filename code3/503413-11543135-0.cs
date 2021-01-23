    [XmlRoot(name="page"]
    public class MyPage
    {
        [XmlElement(name="titel")]
        public string Title { get; set; }
        [XmlElement(name="url")]
        public string Url { get; set; }
    }
