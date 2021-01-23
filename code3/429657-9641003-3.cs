    public IQueryable<CustomInvoice> GetInvoices() 
    { 
        return (from i in this.ObjectContext.Invoices  
                join p in this.ObjectContext.Product equals condition  
                join c in this.ObjectContext.Customer equals condition  
                select new CustomInvoice
                { 
                    InvoiceID = i.ID, 
                    InvoideNumber = i.InvoiceNumber, 
                    ProductID = p.ID, 
                    ProductName = p.Name, 
                    CustomerID = c.ID, 
                    CustomerName = c.Name
                }; );  
    } 
