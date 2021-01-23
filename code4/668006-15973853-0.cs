    public class Product
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        //new code
        public virtual Category Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        //remove code below
        //public virtual ICollection<Category> Categories { get; set; }
    }
    
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        //new code
        public virtual ICollection<Product> Products{ get; set; }
    }
