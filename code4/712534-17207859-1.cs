    public class TopicViewModel
    {
        public int TopicId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateOfTopic { get; set; }
        public int Replies { get; set; }
        public int Views { get; set; }
        public string LastPost { get; set; }
        public DateTime? LastPostDate { get; set; }
        public int ForumId { get; set; }
    }
