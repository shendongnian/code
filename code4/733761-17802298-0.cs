    public class Comment
    {
        public string id { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public string last_update { get; set; }
    }
    public class Post
    {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public string last_update { get; set; }
        public List<Comment> Comments { get; set; }
    }
    public class RootObject
    {
        public List<Post> Posts { get; set; }
    }
