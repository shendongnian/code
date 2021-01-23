    public class CreateViewModel
    {
        public string Reference { get; set; }
        public int? CategoryId { get; set; }
        public string Content { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }
    }
