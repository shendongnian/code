            public Customer GetCustomerByHireDates(string hirefromdate, string hiretodate)
        {
            var customerID = HireDates.Where(h => h.HireFromDate == hirefromdate && h.HireToDate == hiretodate).Select(sl=>sl.CustomerID).FirstOrDefault();
            Customers customer = null;
            var customers = new Customers().GetCustomerCollection();
            if (customers != null)
            {
                customer = customers.Where(c=>c.CustomerID==customerID).FirstOrDefault();
                
            }
            return customer;  
        }
