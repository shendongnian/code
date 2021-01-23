    myDbContext db= new myDbContext();
    var requiredList = db.Customers.Where(s=>
                                   (s.CustomerSalesPeople ==null)
                                   ||
                                   (s.CustomerSalesPeople.Select(o=>o.Id).Contains(s.Id))
                                   ).ToList();
   
