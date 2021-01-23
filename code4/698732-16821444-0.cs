    [HttpPost]
    public ActionResult Create(NonProject myRecord, HttpPostedFileBase PDF)
    {
        try
        {
            //Save PDF here            
           // Save form values to dB
        }
        catch
        {
            //Log error show the view with error message
             ModelState.AddModelError("","Some error occured");
            return View(myRecord);
        }
    }
