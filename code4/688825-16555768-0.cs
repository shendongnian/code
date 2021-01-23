    Employees.Where(e => Customers.Any(c=> c.CustomerName == e.EmployeeName)).ToList()
        .ForEach(e=> { 
             Employees.Remove(e); 
             Customers.RemoveAll(c => c.CustomerName == e.EmployeeName);
         });
