    public class MyBookList
    {
        public string ID { get; set; }
        public string TYPE { get; set; }
        public string TITLE { get; set; }
        public string PRICE { get; set; }
        public string IMAGE { get; set; }
        [JsonProperty("DOWNLOAD LINK")]
        public string DOWNLOADLINK { get; set; }
    }
    public class DataJsonAttributeContainer
    {
        [JsonProperty("My Book List")]
        public List<MyBookList> MyBookList { get; set; }
        public int success { get; set; }
    }
