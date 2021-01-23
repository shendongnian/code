    public ActionResult Delete(string id, string productid)
    {             
    	int records = DeleteItem(id,productid);
    	if (records > 0)
    	{	 
            // since you are redirecting store the error message in TempData
    	    TempData["CustomError"] = "The item is removed from your cart";
    	    return RedirectToAction("Index1", "Shopping");
    	}
    	else
    	{
    		ModelState.AddModelError(string.Empty,"The item cannot be removed");
    		return View("Index1");
    	}
    }
    
    public ActionResult Index1()
    {
        // check if TempData contains some error message and if yes add to the model state.
    	if(TempData["CustomError"] != null)
    	{
    		ModelState.AddModelError(string.Empty, TempData["CustomError"].ToString());
    	}
    	
    	return View();
    }
