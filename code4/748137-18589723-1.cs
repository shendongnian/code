    public class Result
    {
        public List<string> sample1 { get; set; }
        public string sample2 { get; set; }
    }
    
    public class Datum
    {
        public int key { get; set; }
        public Result result { get; set; }
    }
    
        public class RootObject
        {
        public string serverTime { get; set; }
        public List<Datum> data { get; set; }
    }
    
