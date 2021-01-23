    public interface IProductRepo
    {
        List<Product> GetProducts();
        Product GetProduct(int Id);
        void DeleteProduct(int Id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
    }
    public class ProductRepo : IProductRepo
    {
        //Implementation of IProductRepo
    }
