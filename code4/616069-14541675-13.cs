    class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public List<Category> Children { get; set; }
        public IEnumerable<Category> Descendants {
            get
            {
                return (from child in Children
                        select child.Descendants).SelectMany(x => x).
                        Concat(new Category[] { this });
            }
        }
    }
