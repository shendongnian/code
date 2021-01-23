    [AcceptVerbs(HttpVerbs.Post)] 
    public ActionResult Create(Dinner dinner) {
        if(ModelState.IsValid) {
            try {
                dinner.HostedBy = "SomeUser"; 
    
                dinnerRepository.Add(dinner);
                dinnerRepository.Save();
    
                return RedirectToAction("Details", new {id = dinner.DinnerID }); 
            } 
            catch(ValidationException ex) 
            {
                ValidationResult result = new ValidationResult(ex.Errors);
                result.AddToModelState(ModelState, string.Empty);
            } 
        } 
        return View(dinner); 
    } 
