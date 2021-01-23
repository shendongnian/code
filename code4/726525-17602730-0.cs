    [HttpPost]
    public ActionResult Index(BillViewModel billViewModel)
    {
        bill.ClientList = billRepo
            .GetAllClients()
            .ToList()
            .Select(x => new SelectListItem
            {
                Value = client.ClientId.ToString(), 
                Text = client.Name
            })
            .ToList();
    
        return View(billViewModel);
    }
