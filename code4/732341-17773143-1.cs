    public ActionResult Register()
    {
    	using (var db = new DataContext())
    	{
    		var departments = db.Departments.Select(department => new SelectListItem 
    																	{ 
    																		Value = department.Id, 
    																		Text = department.Name
    																	}).ToList();
    		
    		var registerModel = new RegisterModel {	DepartmentsList = departments };
    		return View(registerModel);
    	}
    }
