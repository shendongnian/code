    public class Build
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
    
        [JsonIgnore]
        public TimeSpan Duration { get { return StartedAt.Subtract(FinishedAt); }}
    }
