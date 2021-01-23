    public class ProductCollection
    {
        public IEnumerable<getProductsPrices_Result> Products { get; set; }
        public int Quantity { get { return Products.Count; } }
        public decimal TotalPrice 
        {
            get
            {
                return Products.Sum(p => p.finalProductPrice );
            }
        }
    }
