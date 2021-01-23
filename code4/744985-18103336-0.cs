    public class Room
    {
        public string url { get; set; }
        public string desc { get; set; }
    }
    public class RoomTypes
    {
        [JsonProperty("Fenway Room")]
        public Room FenwayRoom { get; set; }
        [JsonProperty("Commonwealth Room")]
        public Room CommonWealthRoom { get; set; }
    }
