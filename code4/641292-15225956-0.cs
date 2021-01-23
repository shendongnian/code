    Entity invoiceline = null;
    foreach (Entity contractdetail in contractdetails.Entities)
    {
        invoiceline = new Entity("invoicedetail");
        ...
    }
