    var supplierCusts =
    	suppliers.GroupJoin(customers, s => s.Country, c => c.Country, (s, c) => new { Supplier = s, Customers = c })
    		.OrderBy(i => i.Supplier.SupplierName)
    		.SelectMany(r => r.Customers.DefaultIfEmpty(), (r, c) => new
    		{
    			Country = r.Supplier.Country,
    			CompanyName = c == null ? "(No customers)" : c.CompanyName,
    			SupplierName = r.Supplier.SupplierName
    		});
