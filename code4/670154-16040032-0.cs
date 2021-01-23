	public ActionResult MyAction(FormCollection f)
	{
		if (f.Count == 0)
			{
				Debug.WriteLine("Hello");
			}
			
			return View();
	}
