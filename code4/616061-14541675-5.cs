    class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public List<Category> Children { get; set; }
    }
