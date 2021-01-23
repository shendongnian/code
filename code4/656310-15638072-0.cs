    public class SalesDetail
    {
        public string Brand {get; set;}
        public string Product {get; set;}
        
        public override string ToString()
        {
            return string.Format("Brand: {0}, Product {1}", Brand, Product);
        }
    }
    
