    from invoice in invoices
    where invoice.IsPaid
    from xr in invoice.InvoiceProducts
    group xr.Quantity * xr.Price
      by new {Code = xr.Product.Code, Invoice = invoice }
      into g
    select new {
      Code = g.Key.Code,
      Invoice = g.Key.Invoice,
      SalesValue = g.Sum()};
