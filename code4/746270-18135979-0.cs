    var bindableInvoiceProducts = db.Invoices_Products
        .Where(ip => ip.Invoice.IsPaid)
        .GroupBy(ip => ip.Product.Code, 
                 (code, ips) => new BindableInvoiceProduct()
                    {
                        Code = code,
                        SalesValue = ips.Sum(ip => (ip.Price*ip.Quantity))
                    })
        .ToList();
