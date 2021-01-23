    public ActionResult Index()
    {
    
        var invoice = InvoiceLogic.GetInvoice(this.HttpContext);
    
        // Set up our ViewModel
        var pageViewModel = new InvoicePageViewModel
        {
            Products = proent.Products.ToList(),
            Services = proent.Services.ToList(),
            InvoiceViewModel = new InvoiceViewModel
        {
    
            InvoiceItems = invoice.GetInvoiceItems(),
            Clients = proent.Clients.ToList(),
            InvoiceTotal = invoice.GetTotal()
        }
    };
        // Return the view
        return View(pageViewModel);
    }
