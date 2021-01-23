    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
        void DeleteOrder(Order order);
    }
    public class OrderRepository
    {
        StoreDbContext db = new StoreDbContext();
        public IQueryable<Order> Orders
        {
            get { return db.Orders.Include("Products"); }
        }
        
        public void SaveOrder(Order order)
        {
            db.Entry(order).State = order.ID == 0 ? 
                    EntityState.Added : 
                    EntityState.Modified;
        
            db.SaveChanges();
        }
        
        public void DeleteOrder(Order order)
        {
            db.Orders.Remove(order);
        
            db.SaveChanges();
        }
    }
