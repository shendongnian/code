    public class User
    {
       public string name { get; set; }
       public string url { get; set; }
       public List<Product> product { get; set; }
    }
     public class Product
     {
        public string name { get; set; }
        public Decimal price { get; set; }
     }
