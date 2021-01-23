    public class Product {}
    public class SimpleProduct : Product {}
    public class ServiceProduct : Product {}
    var product = new ProductBuilder()
       .Create<SimpleProduct>()
       .WithPrice(12.5);
