    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public BlogPost()
        {
            Tags = new List<Tag>();
        }
    }
