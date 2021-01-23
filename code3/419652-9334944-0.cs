    var results = from x in context.MyEntities 
                  select new Customer() 
                  { 
                    CustomerID = x.CustomerID, 
                    FirstName = x.FirstName, 
                    LastName = x.LastName, 
                    Gender = x.Gender, 
                    BirthMonth = x.BirthMonth,
                    TotalPurchases = context.PurchaseOrders
                                            .Where(po=>po.CustomerId == x.CustomerId)
                                            .Count()
                  };
