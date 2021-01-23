    public interface IBasketItem
    { 
        /* put some common properties and methods here */
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
    public class A : IBasketItem
    { /* A fields */ }
    public class B : IBasketItem
    { /* B fields */ }
    public class C : IBasketItem
    { /* C fields */ }
    
    public class Basket
    {
        private List<IBasketItem> _items = new List<IBasketItem>();
    
        public void Add(IBasketItem item)
        {
            _items.Add(item);
        }
    
        public IBasketItem Get(string name)
        {
            // find and return an item
        }
    }
