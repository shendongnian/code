    public class ProductController : ApiController
    {
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        public List<Product> GetProducts()
        {
            //other code as needed
            return _repo.GetProducts();
        }
        public Product GetProduct(int id)
        {
            //other code as needed
            return _repo.GetProduct(id);
        }
        public void PostProduct(Product product)
        {
            _repo.CreateProduct(product);
            //other code as needed
        }
        public void PutProduct(Product product)
        {
            _repo.UpdateProduct(product);
            //other code as needed
        }
        public void DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
            //other code as needed
        }
    }
