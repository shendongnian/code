    public class Post
    {
        [Key]
        public Int32 PostId { get; set; }
        public String PostText { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
    
    public class Comment
    {
        [Key]
        public Int32 CommentId { get; set; }
        public String CommentText { get; set; }
        public Post Post { get; set; }
    }
