	public ActionResult MyController(int id)
	{
		Onus onus = GetOnus(int id);
		return View(onus.DueDate.HasValue ? 
                    onus.DueDate.Value.ToShortDateString() : 
                    "(null)");
	}
