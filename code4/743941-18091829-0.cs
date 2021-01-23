    public class Item
    {
        public string title { get; set; }
        public string item_id { get; set; }
        public string thumb_url { get; set; }
        public string teaser { get; set; }
        public string language_id { get; set; }
        public int media_id { get; set; }
        public string views { get; set; }
        public string shares { get; set; }
    }
    public class Payload
    {
        public ICollection<Item> Items { get; set; }
    }
