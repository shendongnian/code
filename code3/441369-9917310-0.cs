    public ActionResult ResetPassword(ResetPasswordViewModel model)
    {
        if (ModelState.IsValid) 
        {
            //do something with the valid model and return
        }
        
        return View(model);
    }
