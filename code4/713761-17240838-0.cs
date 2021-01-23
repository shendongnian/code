    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public Dictionary<string, Data> result { get; set; }
    }
