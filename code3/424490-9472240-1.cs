    public class Article
    {
        public string Text { get; set; }
    }
    
    public class Comment
    {
        public string Text { get; set; }
    }
    
    public class BlogPostViewModel
    {
        public Article Article { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
