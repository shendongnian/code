    public class Product {
        public int ProductId { get; set; }
        public string Name { get; set; }
        // Add this field so I can add the entity to the database using 
        // category id only, no need to instantiate the object
        public int CategoryId { get; set; }
 
        // Map this reference to the field above using the ForeignKey annotation
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
    public class Category {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
