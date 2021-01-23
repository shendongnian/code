    public class Room
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }
    }
    public class RoomTypes
    {
        [JsonProperty("Fenway Room")]
        public Room FenwayRoom { get; set; }
        [JsonProperty("Commonwealth Room")]
        public Room CommonWealthRoom { get; set; }
    }
