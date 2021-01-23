    [HttpPost]
    public ActionResult ValidateHvm(ValidateModel model)
    {
        var result = HvmService.ValidateProject(model);
        
        if(result == false){ //or whatever
           ModelState.AddModelError("","Error");
        }
            return View("MyView", model)
    }
