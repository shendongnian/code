    var employeeProducts = new List<EmployeeProduct>();
    employeeProducts.Add(new EmployeeProduct(1, 2, "XYZ"));
    employeeProducts.Add(new EmployeeProduct(1, 5, "ZXY"));
    employeeProducts.Add(new EmployeeProduct(2, 2, "XYZ"));
    var way1 = employeeProducts.Select(
        ep => new ProductCount
                    {
                        ProductNumber = ep.ProductID,
                        EmployeeNumber = ep.EmployeeID,
                        CountProducts = employeeProducts.Count(epc => epc.ProductID == ep.ProductID)
                    });
    var way2 = employeeProducts
        .GroupBy(ep => ep.ProductID)
        .SelectMany(epg => epg.Select(
            ep => new ProductCount
                        {
                            ProductNumber = ep.ProductID,
                            EmployeeNumber = ep.EmployeeID,
                            CountProducts = epg.Count()
                        }));
