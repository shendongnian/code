    public class Product
    {
       // ...
       internal ProductState State
       {
         get
         {
           // return this.State as is, if you trust the caller (repository),
           // or deep clone it and return it
         }
       }
    }
    // inside repository.Add(Product product):
    dbContext.Add(product.State);
