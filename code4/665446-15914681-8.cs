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
            doc.Country.Add("USA");
            doc.Country.Add("Bulgaria");
            doc.Country.Add("France");
            doc.DocumentType = "example";
            Result result = new Result();
            result.Documents.Add(doc);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            System.Console.WriteLine(json);
        }
    }
