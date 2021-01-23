    public class BlogViewModel
    {
        public PostViewModel Post { get; set; }
    
        public string TopicID { get; set; }
        public IEnumerable<SelectListItem> Topics { get; set; }
    }
