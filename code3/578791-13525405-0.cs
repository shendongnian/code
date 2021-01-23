    public ViewResult Index()
        {
            var cust = db.orders.Include(c => c.customer).Select(x => new Customers
                    {
                        CustomerID = x.CustomerID,
                        OrderName = x.Orders.OrderName,
                    });
            return View(cust.Take(10).ToList());
        }
