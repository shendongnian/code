    public class Product {}
    public class SimpleProduct : Product {}
    public class ServiceProduct : Product {}
    var product = new ProductBuilder<SimpleProduct>()
       .WithPrice(12.5);
