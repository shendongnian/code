    public class Post
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string PostText { get; set; }
    }
