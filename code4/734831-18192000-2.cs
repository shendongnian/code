    public class SingleSelection
    {
        public string Questions { get; set; }
        public string Url { get; set; }
        public string marks { get; set; }
        public string description { get; set; }
        [JsonConverter(typeof(GenericJsonConverter<string, string>))]
        public Dictionary<string, string> options { get; set; }
        [JsonProperty("Question Type")]
        public string QuestionType { get; set; }
        [JsonProperty("correct Ans")]
        public List<string> correctAns { get; set; }
    }
    public class Detail
    {
        public List<SingleSelection> single_selection { get; set; }
    }
    public class RootObject
    {
        public Detail detail { get; set; }
    }
