    {
           InvoiceId = i.InvoiceId,
           SumPayments = 
              db.PaymentInvoices.Any(pi => pi.InvoiceId == i.InvoiceId)
              ? db.PaymentInvoices.Where(pi => pi.InvoiceId == i.InvoiceId)
                                  .Select(pi => pi.AmountAllocated).Sum()
              : 0
    };
