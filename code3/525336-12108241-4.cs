    [HttpPost]
    public ActionResult Register(AccountModel model)
    {
       if(ModelState.IsValid)
       {
          // Check for Model.State property value here for selected state   
          // Save and Redirect (PRG Pattern)
       }
       return View(model);
    }  
