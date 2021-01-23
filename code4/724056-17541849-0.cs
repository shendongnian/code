    public class XYZ: DomainObject
    {   
        public decimal Price { get; set; }
    
        public string PriceString
        {
            get { return Price.ToString("N"); }
        }
    
        public decimal Commission { get; set; }
    }
