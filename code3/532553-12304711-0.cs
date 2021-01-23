    public class JsonTestResults
    {
        public string status { get; set; }
        public IEnumerable<TempLink> links { get; set; }
    }
    public class TempLink
    {
        public Link link;
    }
    public class Link
    {
        public string link_name { get; set; }
        public string link_id { get; set; }
    }
