    public class CategoryViewModel
    {
        public string name { get; set; }
        public int id { get; set; }
    }
    
    public class CreateNewsViewModel
    {
        public string news_title { get; set; }
        public string news_content { get; set; }
        public string news_teaser { get; set; }
        public string CategoryViewModel category { get; set; }
    }
