    class Customer
    {
       private List<Order> orders();
       Customer()
       {
          this.orders = new List<Order>();
       }
    
       public IEnumerable<Order> Orders { get { return this.orders.AsEnumerable(); } }
    
       // you will need a public method to mutate the collection
    
       public void AddOrder(Order order)
       {
          // implement custom logic, fire domain events, etc
          this.orders.Add(order);
       }
    }
