	public ActionResult CallBack()
	{
		if (AcceptPayment() == "OK")
		{
		    // simply launches the task and moves on
		    Task.Run(LenghtyTask()); 
		}
	
		return RedirectToUrl("MyWebSite");   
	} 
