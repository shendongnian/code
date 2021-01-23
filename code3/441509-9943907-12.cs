    IEnumerable<Invoice> inv = repository.Query
                                         .Invoices.ThatAre
                                                  .Started()
                                                  .Unfinished()
                                                  .And.WithoutError();
    // or
    IEnumerable<Invoice> inv = repository.Query.Invoices.ThatAre.Started();
    // or
    Invoice inv = repository.Query.Invoices.ByInvoiceNumber(invoiceNumber);
