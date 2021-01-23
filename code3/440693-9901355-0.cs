    public interface IPricedItem
    {
        double Price { get; }
    }
    
    class Product : IPricedItem { ... }
    class ProductCombo : IPricedItem { ... }
    
    public class Whatever
    {
        public List<IPricedItem> StoreItems { get; set; }
    }
