    return
        (from i in db.QB_INVOICES_HEADER
         where i.ClientID == cId
         // have the database do the sorting
         orderby i.InvoiceNumber descending
         select i)
         // break out of the DB query to make InvoiceModel
        .ToEnumerable()
        .Select(itm => new InvoiceModel()
        {
            InvoiceNumber = itm.InvoiceNumber,
            InvoiceSentDt = itm.InvoiceSentDt,
            InvoiceDt = itm.InvoiceDt,
            Amount = itm.Amount,
            Term = itm.Term,
            ClientName = itm.CI_CLIENTLIST.ClientName
        })
         // only create one list as the last step
        .ToList();
