    public interface IPostable
    {
        Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        PostType PostType { get; }
    }
    public class Photo : IPostable
    {
        //special properties for photo
        public string Url { get; set; }
        //implement the interface
        public PostType PostType { get { return PostType.Photo; } }
    }
    public class Status : IPostable
    {
        public string Text { get; set; }
        public PostType PostType { get { return PostType.Status; } }
    }
