    public class Product 
    {
        public int ProductID { get; set; }     
        public decimal Price { get; set; }
        public int ProductCategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductStorage Storage { get; set; }
    
        [NotMapped]
        public int Quantity { get { return this.Storage.Quantity; }  }
    }
