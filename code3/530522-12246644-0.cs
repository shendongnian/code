    public interface IProductRepository
    {
      string ConnectionString { get; set; }
      Product GetById(int productId);
      Product GetByName(string productName);
    }
