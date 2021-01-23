    public class ShoppingBasket
    {
        public List<OrderItem> Orders { get; set; }
        public ShoppingBasket()
        {
            Orders = new List<OrderItem>();
        }
    
        public new void Add(OrderItem orderItem)
        {
            Orders.Add(orderItem);
        }
   
    
        public new void Remove(OrderItem orderItem)
        {
            Orders.Remove(orderItem);
        }
    }
