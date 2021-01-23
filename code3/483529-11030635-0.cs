          public class Order {
      public long OrderId { get; set; }
      public string Name { get; set; }}
       
    
        public class Rep
        {
            private List<Order> orders { get; set; }
    
            public void Q()
            {
                long[] testArray = {123, 456};
                var res  = orders.Intersect(orders);
            }
        }
