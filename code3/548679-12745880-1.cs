    public class Quote{
        public int Id;
        public Product Product;
        public double Amount;
    }
    
    public class Product{
        public int Id;
        public Quote Quote;
        public string Name;
    }
