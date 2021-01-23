    [HttpPost]
    public ActionResult Index(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            // Send email using Model information.
    
            return RedirectToAction("Gracias", model.ID);
        }
    
        return View(model);
    }
    public ActionResult Gracias(int contactID)
    {
        ContactModel model = new ContractRepository().GetContact(contactID);
        return View(model);
    }
