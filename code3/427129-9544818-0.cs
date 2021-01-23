    var _sale = from emp in setupEmployees
                join sales in vwSaleTargets on emp.EmployeeID equals sales.EmployeeID
                join price in vwPeriodPricings
                   on new { sales.SKUID, sales.PeriodID } 
                   equals new { SKUID = (int?)price.SKUID, PeriodID = (int?)price.PeriodID }
                join sk in setupSKUs on sales.SKUID equals sk.SKUID
                where emp.EmployeeID == 123 && sales.StartDate.Year == 2012 && sales.StartDate.Month == 2
                select new 
                { 
                    EmployeeName = emp.EmployeeName, 
                    StartDate = sales.StartDate,
                    SalesQuantity = sales.SalesQuantity, 
                    ExFactoryPrice = price.ExFactoryPrice, 
                    SKUID = sk.SKUID,
                    SKUName = sk.SKUName 
                };
    
    var lstSale = _sale.ToList(); //to avoid n+1 queries in case of grouping
    
    // Run through lstSale here
    foreach(var item in lstSale)
    {
      Console.WriteLine(item);
    }
    
    var sale2 = from x in lstSale
                group x by new { x.SKUID, x.EmployeeName } into grouping
                select new 
                {
                     EmployeeName = grouping.Key.EmployeeName,
                     SKUID = grouping.Key.SKUID,
                     SKUName = grouping.SKUName,
                     MonthSale =(double?)grouping
                              .Where(x => x.StartDate.Month == 2 && 
                                          x.StartDate.Year == 2012)
                              .Select(t=>t.SalesQuantity)
                              .Sum(t=>t.Value)?? 0,
                     MonthSaleValue = (double?)grouping
                              .Where(x => x.StartDate.Month == 2 && 
                                          x.StartDate.Year == 2012)
                              .Sum(x => x.SalesQuantity * x.ExFactoryPrice)  
                                 ?? 0,
                };
    Console.WriteLine(sale2.OrderBy(x => x.SKUName).ToList());
