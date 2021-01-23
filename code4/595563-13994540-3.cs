    public class Item
    {
        public int Id { get; set; }
    }
    public class Article : Item
    {
        public string Text { get; set; }
    }
    public class Gallery : Item
    {
        public string Type { get; set; }
        public List<Photo> Photos { get; set; }
    }
    public class Video : Item
    {
        public string VideoHash { get; set; }
    }
