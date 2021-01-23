    IQueryable<GenericCustomer> Customers 
    {
        get
        {
            return from c in db.Customers1
                    select new GenericCustomer() 
                    { Name = c.Name, ... }
        }
    }
