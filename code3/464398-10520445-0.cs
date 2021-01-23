    public class OrderView
    {
      public int Id { get; set; }
      public IEnumerable<OrderItem> OrderItems { get; set; }
      ...
    }
    
    var query = from o in context.Orders
                select new OrderView
                {
                  Id = o.Id,
                  OrderItems = //custom filtering
                  ...
                 };
   
