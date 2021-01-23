    [HttpPost]
    public ActionResult Create(CompanyModel company)
    {
        if (ModelState.IsValid)
        {
            //save company ...
        }else{
            return View(company)
        }
    }
