    public ActionResult Edit(EmployeeModel empmodel)
    {
    
         	ModelState.Remove("Password");
         	ModelState.Remove("ConfirmPassword");
    	    if (ModelState.IsValid)
    	    {
    	      //do something
    	    }
     	 
    }
