    //Normalized Database classes
    public class Seller
    {
        public int Id { get; set; }  // primary key
        public string Name { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }  // primary key
        public int SellerId { get; set; } // foreign key
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
