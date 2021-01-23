    [HttpPost]      
    public ActionResult Create(Employee emp)      
    {         
    if (YourServerValidation() == false) 
    {
       ModelState.AddModelError("controlName", "Invalid value");
    }
    if (ModelState.IsValid)          
    {             
     //Save the employee in DB first and then redirectToAction.
                return RedirectToAction("Index");          
    }
    else
    { 
       return View();
    }
