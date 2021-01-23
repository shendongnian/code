    public ActionResult PollForUpdate(YourModel Model)
	{
		ModelState.Clear();
        //fill your Model object with your database stuff
		return View("YourPartial", Model);
	}
    
