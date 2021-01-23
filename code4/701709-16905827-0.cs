    var invoices2 = 
        from i in ctx.Invoices.Include(inv => inv.BatchInvoices.Select(imp => imp.ImportBatch))
        join bi in ctx.BatchInvoices on i.Id equals bi.InvoiceId
        join ib in ctx.ImportBatches on bi.ImportBatchId equals ib.Id
        select new InvoiceDTO
        {
            DocumentDate = i.DocumentDate,
            DocumentNumber = i.DocumentNumber,
            DueDate = i.DueDate,
            InvoiceId = i.Id,
            InvoiceDetails = 
                 from b in i.BatchInvoices
                 select new InvoiceDetailDTO
                 {
                     Current = b.Current,
                     Days1To30 = b.Days1To30,
                     Days31To60 = b.Days31To60,
                     Days61To90 = b.Days61To90,
                     DaysOver90 = b.DaysOver90,
                     RunDate = b.ImportBatch.FileGeneratedDate
                 }
        };
