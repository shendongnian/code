    public class TagModel
    {
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    
        [NavigationProperty]
        public List<ContentModel> Contents { get; set; }
    }
