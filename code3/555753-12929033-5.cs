    var result = JsonConvert.DeserializeObject<Result>(jsonString);
    public class Result
    {
        [JsonProperty("status")]
        public int Status;
        [JsonProperty("data")]
        public List<Item> Data;
    }
    public class Item
    {
        [JsonProperty("report_date")]
        public string ReportDate;
        [JsonProperty("subid")]
        public string SubId;
        [JsonProperty("revenue")]
        public string Revenue;
        [JsonProperty("clicks")]
        public string Clicks;
    }
