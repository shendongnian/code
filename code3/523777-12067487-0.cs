    [HttpPost]
	public ActionResult A(Model m, string s)
	{
		if (ModelState.IsValid) 
		{
			if (m.l == null || m.k == null)
			{
				//Do something.                    
			}
			else
				RedirectToAction("B", m); // check this
		}
		return View(m);    
	}	
	public ActionResult B(Model model)
	{
		return View(model);
	}
