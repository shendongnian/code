    var results = from x in context.MyEntities
                  join po in context.PurchaseOrders on x.CustomerID equals po.CustomerID into purchaseOrders
                  select new Customer() 
                  { 
                    CustomerID = x.CustomerID, 
                    FirstName = x.FirstName, 
                    LastName = x.LastName, 
                    Gender = x.Gender, 
                    BirthMonth = x.BirthMonth,
                    TotalPurchases = purchaseOrders.Count()
                  };
