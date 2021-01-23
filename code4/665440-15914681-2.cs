    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, object>> dataResults = GetResults();           
            Dictionary<string, List<Dictionary<string, object>>> myList = 
                          new Dictionary<string, List<Dictionary<string, object>>>();
            myList.Add("Documents", dataResults);
            string ans = JsonConvert.SerializeObject(myList, Formatting.Indented);
            System.Console.WriteLine(ans); 
        }
        public static List<Dictionary<string, object>> GetResults()
        {
            List<Dictionary<string, object>> dictList = new List<Dictionary<string, object>>();
            Dictionary<string, object> dataFrmDb = new Dictionary<string, object>();
            dataFrmDb.Add("Title", "An Example Document");
            dataFrmDb.Add("DatePublished", DateTime.Now.ToString());
            dataFrmDb.Add("DocumentURL", "http://www.example.org/documents/1234");
            dataFrmDb.Add("ThumbnailURL", "http://www.example.org/thumbs/1234");
            dataFrmDb.Add("Abstract", "This is an example document.");
            dataFrmDb.Add("Sector", "001");
            dataFrmDb.Add("Country", new List<string> { "USA", "Bulgaria", "France" });
            dataFrmDb.Add("Document Type", "example");
            dictList.Add(dataFrmDb);
            return dictList;
        }
    }
