    class Result
    {
        public List<Document> Documents { get; set; }
        public Result()
        {
            Documents = new List<Document>();
        }
    }
    class Document
    {
        public string Title { get; set; }
        public string DatePublished { get; set; }
        public string DocumentURL { get; set; }
        public string ThumbnailURL { get; set; }
        public string Abstract { get; set; }
        public string Sector { get; set; }
        public List<string> Country { get; set; }
        [JsonProperty(PropertyName="Document Type")]
        public string DocumentType { get; set; }
        public Document()
        {
            Country = new List<string();
        }
    }
