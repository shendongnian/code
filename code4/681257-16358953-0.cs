    public class StandardProductProcessor : IBaseProductProcessor<StandardProduct> 
    {
        public StandardProductProcessor(StandardProduct product)
        {
            Product = product;
        }
    
        public StandardProduct Product { get; private set; }
    }
