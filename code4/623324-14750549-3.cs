    public ActionResult Details(short id = 0)
    {
    	AccCompany accComp = db.AccCompany.Find(id);
		
	if (accComp == null)
    	{
    		return HttpNotFound();
    	}
		
	SomeViewModel vm = new SomeViewModel();
		
	vm.Company = accComp.Comany;
	vm.CostCentre = accComp.AccControl.CostCentre;
    	
    	return View(vm);
    }
