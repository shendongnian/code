    [HttpPost]
    public ActionResult Create(CompanyCreate model)
    {
        /* Fill model with countries again */
        model.FillCountries();
    
        if (ModelState.IsValid)
        {
            /* Save it to database */
            unitOfWork.CompanyRepository.InsertCompany(model.Company);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    
        // If we got this far, something failed, redisplay form
        return View(model);
    }
