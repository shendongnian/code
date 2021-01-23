    public class BlogPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public DateTime DateTimePosted { get; set; }
        public string Author { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime? CustomDate { get; set; }
    
        public BlogPost()
        { }
    
        public BlogPost(int id, string title, string content, string author, DateTime? customDate)
        {
            this.ID = id;
            this.Title = title;
            this.Content = content;
            this.DateTimePosted = customDate ?? DateTime.Now;
            this.Author = author;
        }
    
    }
