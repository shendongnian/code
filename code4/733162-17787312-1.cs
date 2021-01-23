    public class ShoppingBasket
    {
        public List<OrderItem> Orders { get; set; }
        public ShoppingBasket()
        {
            Orders = new List<OrderItem>();
        }
    
        public void Add(OrderItem orderItem)
        {
            Orders.Add(orderItem);
        }
   
    
        public void Remove(OrderItem orderItem)
        {
            Orders.Remove(orderItem);
        }
    }
