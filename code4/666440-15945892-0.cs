    public class dto
    {
        public long Value { get; set; }
        public int Count { get; set; }
        public bool HasCount { get { return Count > 0; } }
    }
