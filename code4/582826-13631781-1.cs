    public class Statistics
    {
        public int PagesParsed { get; set; }
    }
    
    var collection = new Dictionary<string, Statistics>();
    collection.Add("Site A", new Statistics { PagesParsed = 42 });
    var siteAStatistics = collection["Site A"];
