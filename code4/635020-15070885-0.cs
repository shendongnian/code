        Suppliers
       .GroupJoin (
          Customers, 
          sup => sup.Country, 
          cust => cust.Country, 
          (sup, cs) => 
             new  
             {
                sup = sup, 
                cs = cs
             }
       )
       .SelectMany (
          temp0 => temp0.cs.DefaultIfEmpty (), 
          (temp0, c) => 
             new  
             {
                temp0 = temp0, 
                c = c
             }
       )
       .OrderBy (temp1 => temp1.temp0.sup.CompanyName)
       .Select (
          temp1 => 
             new  
             {
                Country = temp1.temp0.sup.Country, 
                CompanyName = (temp1.c == null) ? "(No customers)" : temp1.c.CompanyName, 
                SupplierName = temp1.temp0.sup.CompanyName
             }
       )
