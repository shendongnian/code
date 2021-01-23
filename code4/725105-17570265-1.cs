    public ActionResult About()
    {
        var model = (TempData["Model"] as CustomerBookingModel)
                    ?? new CustomerBookingModel();
        
        return View(model);
    }
