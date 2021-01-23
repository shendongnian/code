    public class ProductService
    {
       private readonly IProductRepository repository
       public ProductService(IProductRepository repository){
          this.repository = repository
       }
    // ........ the code of your BLL
    }
