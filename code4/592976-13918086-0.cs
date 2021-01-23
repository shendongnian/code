    var nonUniqueInvoices = from i in returnInvoices
                           select new
                           {
                               i.InvoiceNo,
                               i.InvoiceDate,
                               i.OrderNo,
                               i.CustomerPO,
                           }; // as before
    var uniqueInvoices = nonUniqueInvoices
        .GroupBy(i => i.InvoiceNo)
        .Select(g => g.First());
    GridView3.Datasource = uniqueInvoices; // as before
