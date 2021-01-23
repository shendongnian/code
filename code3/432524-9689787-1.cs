    [HttpGet]
    public ActionResult Register()
    {
         RegisterViewModel viewModel = new RegisterViewModel();
         viewModel.Companies = new SelectList(db.Companies, "CompanyId", "CompanyName");
        
         return View(viewModel);
    }
