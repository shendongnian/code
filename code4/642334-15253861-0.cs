    public class MyFeedClass
    {
        public Dictionary<string,string> data { get; set; }
    }
    new JavaScriptSerializer().Deserialize<MyFeedClass>(data)
