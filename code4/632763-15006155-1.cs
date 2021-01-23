    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual List<BlogPost> BlogPosts { get; set; }
        public Tag()
        {
            BlogPosts = new List<BlogPost>();
        }
    }
