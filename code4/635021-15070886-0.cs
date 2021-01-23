    var supplierCusts =
        suppliers.GroupJoin(customers, s => s.Country, c => c.Country, (s, c) => new { Suppliers = s, Customers = c})
            .OrderBy(i => i.Suppliers.SupplierName) 
            .SelectMany(x => x.Customers , (x, p) => new
                {
                    Country = p.Country,
                    CompanyName = (x == null ? "(No customers)" : p.CompanyName),
                    SupplierName = p.SupplierName
                });
