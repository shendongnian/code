    public class PostViewModel
    {
        public int ReplyTo {get; set;}
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
     }
