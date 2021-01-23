    public class RecData1
    {
        public string uid { get; set; }
        public int amount { get; set; }
        public int adjusted_amount { get; set; }
        public Dictionary<string,string> extra_params { get; set; }
    }
    var data = JsonConvert.DeserializeObject<RecData1>(payload);
