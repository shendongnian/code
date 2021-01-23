    public class CustomersController 
      : CrudController<Customer>
    {
      public CustomersController()
        : base(db => db.Customers)
      {}
    }
    public class ProductsController 
      : CrudController<Product>
    {
      public ProductsController()
        : base(db => db.Products)
      {}
    }
