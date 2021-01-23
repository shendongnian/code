    public void Linq43() 
    { 
        List<Customer> customers = GetCustomerList(); 
      
        var customerOrderGroups = 
            from c in customers 
            select 
                new 
                { 
                    c.CompanyName, 
                    YearGroups = 
                        from o in c.Orders 
                        group o by o.OrderDate.Year into yg 
                        select 
                            new 
                            { 
                                Year = yg.Key, 
                                MonthGroups = 
                                    from o in yg 
                                    group o by o.OrderDate.Month into mg 
                                    select new { Month = mg.Key, Orders = mg } 
                            } 
                }; 
      
        ObjectDumper.Write(customerOrderGroups, 3); 
    } 
