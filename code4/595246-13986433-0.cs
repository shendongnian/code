    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int ProjectDocID { get; set; }
        public int UserID { get; set; }
        public string text { get; set; }
        public string quote { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<CommentVote> CommentVote { get; set; }
        public virtual ICollection<CommentReply> CommentReply { get; set; }
        public ProjectDoc ProjectDoc { get; set; }
        public virtual User User { get; set; }
        public List<ranges> ranges { get; set; }
    }
    public class ranges {
        public int ID { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string startOffset { get; set; }
        public string endOffset { get; set; }
        
    }
