    public ActionResult Index() 
    {
        var model = new PickUpLocationViewModel 
        {
            Address = new AirportAddressViewModel { Terminal = "North" }
        };
        return View(model);
    }
