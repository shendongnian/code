    [HttpPost]
	public ActionResult Index(Model model)
	{
        //Breakpointing on the below line, I can see model.ModelObject.VatRate
		return RedirectToAction("Index");
	}
