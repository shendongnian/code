    var newInvoice = ctx.Set<Invoice>().Create();
    newInvoice.CreationDate = DateTime.Now;
    newInvoice.UserId = 14;
    var detail1 = ctx.Set<InvoiceDetail>().Create();
    detail1.ItemId = 345;
    detail1.ItemCount = 10;
    newInvoice.InvoiceDetails.Add(detail1);
    //...
