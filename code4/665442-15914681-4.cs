    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document();
            doc.Title = "An Example Document";
            doc.DatePublished = DateTime.Now.ToString();
            doc.DocumentURL = "http://www.example.org/documents/1234";
            doc.ThumbnailURL = "http://www.example.org/thumbs/1234";
            doc.Abstract = "This is an example document.";
            doc.Sector = "001";
            doc.Country = new List<string> { "USA", "Bulgaria", "France" };
            doc.DocumentType = "example";
            Result result = new Result();
            result.Documents.Add(doc);
            string json = JsonConvert.SerializeObject(results, Formatting.Indented);
            System.Console.WriteLine(json);
        }
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
        }
    }
