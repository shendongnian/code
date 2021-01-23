    public class From
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    
    public class Datum
    {
        public string id { get; set; }
        public From from { get; set; }
    }
    
    public class FacebookPost
    {
        public List<Datum> data { get; set; }
    }
    
    internal class FacebookResponse<T> where T : class
    {
        public IList<T> Data { get; set; }
        public FacebookResponsePaging Paging { get; set; }
    }
    
    FacebookResponse<FacebookPost> response = JsonConvert.DeserializeObject<FacebookResponse<FacebookPost>>(json);
