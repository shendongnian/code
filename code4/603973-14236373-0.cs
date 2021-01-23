    var city = "Hamburg";
    
    // predicate should accept Address
    var expressions = new Expression<Func<Address, bool>>[] {
        a => a.City == city,
        a => a.City.StartsWith(city)
    };
    
    foreach(var predicate in expressions) {
        queries.Add(
            DB.Customers.Join(
               DB.Addresses.Where(predicate), // filtering here
               c => c.ID, 
               a => a.CustomerID, 
               (c, a) => c) // return customer
        ));
    }
    
        
