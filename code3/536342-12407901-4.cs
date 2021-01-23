    public class SearchArticles
    {
        [XmlArray("articles")]
        [XmlArrayItem("article", Type = typeof(Article))]
        public List<Article> articles { get; set; }
    }
    public class Article
    {
        public long id { get; set; }
        public string partner { get; set; }
        public string number { get; set; }
        public long number_is_generated { get; set; }
        public string status { get; set; }
        public long company_id { get; set; }
    }
