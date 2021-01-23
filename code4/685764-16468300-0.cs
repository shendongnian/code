    public class Category : CategoryViewModel
    {
        public DateTime CreationTime { get; set; }
    }
    public class CategoryViewModel
    {
        public Guid  CategoryId { get; set; }
        public string Name { get; set; }
    }
