    List<Invoice> returnInvoices = (List<Invoice>)Session["Invoices"];
    var partInvoices = returnInvoices
                           .Where(invoice => invoice.PartNo == partNo)
                           .ToList();
    GridView3.DataSource = partInvoices;
    GridView3.DataBind();
