    class Artist
    {
        public Guid mb_id { get; set; }
        public List<Thumb> artistthumb { get; set; }
    }
    class Thumb
    {
        public int id { get; set; }
        public string url { get; set; }
        public int likes { get; set; }
    }
