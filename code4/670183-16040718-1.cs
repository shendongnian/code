    public interface IProduct {
        
          decimal Price {get;}
    }
    
    public class Product : IProduct 
    {
         decimal price;
         public decimal Price {
              get {
                  return price;
              }
         }
    }
    
    public class Product1 : IProduct 
    {
         decimal price;
         public decimal Price {
              get {
                  return price;
              }
         }
    }
    ....
