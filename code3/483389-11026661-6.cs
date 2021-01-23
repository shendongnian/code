    public interface IProduct
    {
        public string ProductNo { get; set; }
    }
    
    public class ProductIn : IProduct { ... }
    public class ProductOut : IProduct { ... }
