    var query =
                from z in db.Employees
                select new
                {   
                    Customer = z.CustomerName,
                    OrderNumber = z.Orders.Where(x => x.OrderDate > fromDate.Date).Count()
                };
    var person = query.OrderByDescending(o => o.OrderNumber).Select(c=>c.Customer).First();
    Console.WriteLine("The customer with the most orders is: " + person);
