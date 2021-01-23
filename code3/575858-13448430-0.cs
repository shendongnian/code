    public abstract class Post
    {
        public Guid Id { get; set; }
    
        public User Owner { get; set; }
    
        public DateTime CreatedDate { get; set; }
    
        public PostType Type { get; set; }
    }
