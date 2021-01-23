    class MyCustomer : Customer
    {
       private ObservableCollection<Order> orders;
       internal bool AllowMutateCollection;
       public MyCustomer()
       {
          this.Orders = this.orders = new ObservableCollection<string>();
          this.orders.CollectionChanged += (_, __) =>
          {
              if(!this.AllowMutateCollection)
              {
                 throw new NotImplementedException();
              }
          };
       }
    }
