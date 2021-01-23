	[HttpPost]
	public ActionResult SubmitValue(MvcSampleApplication.Models.products model)
	{
		TempData["logindata"] = model.EnteredValue;    
		return RedirectToAction("submittedvalues");               
	}                
	public ActionResult submittedvalues()
	{
		var model = new MvcSampleApplication.Models.category();
		string data = string.IsNullOrEmpty(TempData["logindata"]) ? string.Empty : TempData["logindata"].ToString();
		model.lablvalue = data;
		return View(model);            
	}
