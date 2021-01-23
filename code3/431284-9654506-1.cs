    class Stock { /*...*/ }
    class Customer { /*...*/  }
    class Order { /*...*/  }
    class Showroom
    {
        protected List<Stock> StockList;
        protected List<Customer> CustomerList;
        protected List<Order> OrderList;
        public Showroom()
        {
            StockList = new List<Stock>();
            CustomerList = new List<Customer>();
            OrderList = new List<Order>();
        }
        public virtual void addStock(Stock stock)
        {
            StockList.Add(stock);
        }
        public virtual void addCustomer(Customer customer)
        {
            CustomerList.Add(customer);
        }
        public virtual void addOrder(Order order)
        {
            OrderList.Add(order);
        }
        //...
    }
    class deskClerk : Showroom
    {
        public deskClerk()
        {
            CustomerList = new List<Customer>();
        }
        public override void addCustomer(Customer customer)
        {
            CustomerList.Add(customer);
        }
        
        //...
    }
