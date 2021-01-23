    class News
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc {get;set;}
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
    public class Result
    {
        private List<Article> articles = new List<Article>();
        [JsonProperty("articles")]
        public List<Article> Articles { get { return articles; }}
    }
    public class Article
    {
        [JsonProperty("text")]
        public string Text {get;set;}
        [JsonProperty("id")]
        public int Id {get;set;}
        [JsonProperty("date")]
        public long Date {get;set;}
        [JsonProperty("title")]
        public string Title {get;set;}
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }
    }
