    [HttpPost]
    public ActionResult AddAlert(ConfirmUserViewModel model)
    {
       if(ModelState.IsValid)
       {
          //Check for model.ReportedUsers collection and Each items
          //  IsSelected property value.
          //Save and Redirect(PRG pattern)
       }
       return View(model);
    }
