    public class CategoryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class PostItem
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<CategoryItem> Categories { get; set; }
    }
