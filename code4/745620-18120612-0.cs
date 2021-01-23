    public class RootObject
    {
        public Response response { get; set; }
    }
    public class Response
    {
        public int errorFlag { get; set; }
        [JsonProperty("Score Detail")]
        public ScoreDetail ScoreDetail { get; set; }
    }
    public class ScoreDetail
    {
        public ScoreDetail()
        {
            this.Detail = new List<Detail>();
        }
        [JsonProperty("39")]
        public List<Detail> Detail { get; set; }
    }
    public class Detail
    {
        [JsonProperty("test_date")]
        public string TestDate { get; set; }
        [JsonProperty("total_marks")]
        public string TotalMarks { get; set; }
        [JsonProperty("score")]
        public string Score { get; set; }
    }
