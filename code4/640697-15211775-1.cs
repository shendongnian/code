    class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public List<ProductProperty> Properties { get; set; }
    }
    
    class Category
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }
    
    class ProductProperty
    {
       public  int Id { get; set; }
       public  string Name { get; set; }
       public string Value { get; set; }
    }
