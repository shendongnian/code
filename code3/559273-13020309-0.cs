    [HttpPost]
    public ActionResult Index(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            // Send email using Model information.
    
            return View("Gracias", model);
        }
    
        return View(model);
    }
