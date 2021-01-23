    public ActionResult Details(short id = 0)
    {
    	AccCompany accComp = db.AccCompany.Find(id);
    	if (accComp == null)
    	{
    		return HttpNotFound();
    	}
    	return View(accComp);
    }
