    public interface IProduct {
        
          public decimal Price {get;}
    }
    
    public class Product : IProduct 
    {
         decimal price;
         public override decimal Price {
              get {
                  return price;
              }
         }
    }
    
    public class Product1 : IProduct 
    {
         decimal price;
         public override decimal Price {
              get {
                  return price;
              }
         }
    }
    ....
