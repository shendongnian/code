    class JSONResponse
    {
        public Line ROOT;
    }
    class Line
    {
        [JsonProperty("Time")]
        public Timestamp Time { get; set; }
        [JsonProperty("S")]
        public List<Station> S { get; set; }
    }
    class Timestamp
    {
        [JsonProperty("@TimeStamp")]
        public string @TimeStamp { get; set; }
    }
    class Station
    {
        [JsonProperty("@Code")]
        public string @Code { get; set; }
        [JsonProperty("@N")]
        public string @N { get; set; }
        [JsonProperty("P")]
        public List<Platform> P { get; set; }
    }
    class Platform
    {
        [JsonProperty("@N")]
        public string @N { get; set; }
        [JsonProperty("@Code")]
        public string @Code { get; set; }
        [JsonProperty("T")]
        public JToken T { get; set; }
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (this.T != null)
            {
                if (this.T is JArray)
                {
                    this.Trains = JsonConvert.DeserializeObject<List<Train>>(this.T.ToString());
                }
                else
                {
                    Train t = JsonConvert.DeserializeObject<Train>(this.T.ToString());
                    this.Trains = new List<Train>() { t };
                }
            }
        }
        public List<Train> Trains;
    }
    class Train
    {
        [JsonProperty("@S")]
        public string @S { get; set; }
        [JsonProperty("@T")]
        public string @T { get; set; }
        [JsonProperty("@D")]
        public string @D { get; set; }
        [JsonProperty("@C")]
        public string @C { get; set; }
        [JsonProperty("@L")]
        public string @L { get; set; }
        [JsonProperty("@DE")]
        public string @DE { get; set; }
    }
