    [HttpPost]      
    public ActionResult Create(Employee emp)      
    {         
    if (YourServerValidation(emp) == false) 
    {
        ModelState.AddModelError("EmpName", "Invalid value");
    }
    if (ModelState.IsValid)          
    {             
        //Save the employee in DB first and then redirectToAction.
        return RedirectToAction("Index");          
    }
    else
    { 
        return View(emp);
    }
