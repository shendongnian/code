    public interface IProductMapper {
      IProduct Unmap(ProductData data);
      ProductData Map(IProduct product);
    }
    public static class ProductMapperFactory {
      public static IProductMapper GetMapper(ProductData data) {
        if (data.Type == "ConcreteProduct") return new ConcreteProductMapper();
        else if ...
      }
      public static IProductMapper GetMapper(IProduct product) {
        if (product is ConcreteProduct) return new ConcreteProductMapper();
        else if ...
      }
    }
 
    public class ConcreteProductMapper : IProductMapper {
      public IProduct Unmap(ProductData data) {
        var product = new ConcreteProduct();
        // map properties
        return product;
      }
      public ProductData Map(IProduct data) {
        var data = new ProductData();
        // map data
        return data;
      }
    }
