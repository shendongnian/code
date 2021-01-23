    public ViewResult Index()
        {
            var cust = db.Customers.get().Select(x => new Customers
                    {
                        CustomerID = x.CustomerID,
                        OrderName = x.Orders.OrderName,
                    });
            return View(cust.Take(10).ToList());
        }
