    customer
    .invoices
    .OrderByDescending(i => i.Date)
    .GroupJoin(context.Orders,
        invoice => invoice.OrderID,
        order => order.OrderID,
        (invoice, orders) => new
        {
            invoice = invoice,
            OrderNotes = orders.SingleOrDefault()==null?"":orders.SingleOrDefault().Notes
        })
    .ToList()
