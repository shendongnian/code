    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public override int GetHashCode()
        {
            return CategoryId.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Category c2 = obj as Category;
            if (c2 == null) return false;
            return CategoryId == c2.CategoryId;
        }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        publlic Category Category { get; set; }
        public override int GetHashCode()
        {
            return ProductId.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Product p2 = obj as Product;
            if (p2 == null) return false;
            return ProductId == p2.ProductId;
        }
    }
