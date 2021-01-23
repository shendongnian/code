    var result = JsonConvert.DeserializeObject<List<MyObject>>(str);
    public class MyObject
    {
        public List<List<string>> data { get; set; }
        public string error { get; set; }
        public double statement_time { get; set; }
        public double total_time { get; set; }
    }
