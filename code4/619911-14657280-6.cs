    public class CommentsViewModel
    {
        public IList<Comment> comments { get; set; }
        public CommentsViewModel()
        {
            comments = new List<Comment>();
        }
    }
    public class Comment
    {
        [Required]
        public string commentData { get; set; }
        /** Omitted other properties for simplicity */
    }
