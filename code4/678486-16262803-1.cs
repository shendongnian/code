     public class Condition
    {
        public string code { get; set; }
        public string date { get; set; }
        public string temp { get; set; }
        public string text { get; set; }
    }
    public class Forecast
    {
        public string code { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string text { get; set; }
    }
    public class Guid
    {
        public string isPermaLink { get; set; }
        public string content { get; set; }
    }
    public class Item
    {
        public string title { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public Condition condition { get; set; }
        public string description { get; set; }
        public List<Forecast> forecast { get; set; }
        public Guid guid { get; set; }
    }
    public class Channel
    {
      public Item item { get; set; }
    }
    public class Results
    {
       public Channel channel { get; set; }
    }
    public class Query
    {
      public int count { get; set; }
      public string created { get; set; }
      public string lang { get; set; }
      public Results results { get; set; }
    }
    public class RootObject
    {
       public Query query { get; set; }
    }
