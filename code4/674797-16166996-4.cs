    public ActionResult Index()
    {
        Customer c = (Customer)Session["customer"];
       
        // Items is the navigation property.
        var customerItems = customerRepository.GetItems(c.Id).Items;
        return View();
    }
