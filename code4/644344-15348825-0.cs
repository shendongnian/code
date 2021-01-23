    public string CustomerName
    {
        get
        {
            var db = new Context();
    
            var customer = db.Customers.Find(CustomerId);
            _customerName = customer.Name;
    
            return _customerName;
        }
    }
